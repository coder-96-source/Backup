using MyArticles.HtmlHelpers.Encrypt;
using MyArticles.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyArticles.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private const int TOPIC_PAGE_SIZE = 10; // 10 Topics per page
        private const int ARTICLE_PAGE_SIZE = 10; // 10 articles per page
        private EFDbContext db = new EFDbContext();

        #region Admin
        public ActionResult AdminIndex()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AdminLogin()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdminLogin([Bind(Include = "Name,AccountPassword")] Account account)
        {
            IEncryptable encryptor = new HashEncryption();
            string encryptedPassword = encryptor.Encrypt(account.AccountPassword);
            bool userValid = db.Accounts.Any(u => u.Name.Equals(account.Name) && u.AccountPassword.Equals(encryptedPassword));

            if (userValid)
            {
                FormsAuthentication.SetAuthCookie(account.Name, false);
                return RedirectToAction("AdminIndex");
            }
            return RedirectToAction("AdminLogin");
        }
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }
        #endregion

        #region Topic
        public ActionResult TopicIndex(int page = 1)
        {
            TopicVM topicVM = new TopicVM
            {
                Topics = db.Topics
                    .OrderBy(t => t.TopicId)
                    .Skip((page - 1) * TOPIC_PAGE_SIZE)
                    .Take(TOPIC_PAGE_SIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = TOPIC_PAGE_SIZE,
                    TotalItems = db.Topics.Count()
                }
            };
            return View(topicVM);
        }

        public ActionResult TopicCreate()
        {
            Topic topic = new Topic
            {
                TopicId = (db.Topics.Count() == 0) ? 0 : db.Topics.Max(t => t.TopicId) + 1,
            };
            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TopicCreate([Bind(Include = "TopicId,Name")] Topic topic, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                topic.PictureMimeType = image.ContentType;
                topic.Picture = new byte[image.ContentLength];
                image.InputStream.Read(topic.Picture, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("TopicIndex");
            }
            return View(topic);
        }

        public ActionResult TopicEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TopicEdit([Bind(Include = "TopicId,Name,Picture")] Topic topic, string submit, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                topic.PictureMimeType = image.ContentType;
                topic.Picture = new byte[image.ContentLength];
                image.InputStream.Read(topic.Picture, 0, image.ContentLength);
            }
            switch (submit)
            {
                case "Save":
                    if (ModelState.IsValid)
                    {
                        db.Entry(topic).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    break;
                case "Delete":
                    topic = db.Topics.Find(topic.TopicId);
                    if (topic.Articles.Any())
                    {
                        ViewBag.Message = "To delete this topic, you must delete all the articles related.";
                        return View("TopicEdit", topic);
                    }
                    db.Topics.Remove(topic);
                    db.SaveChanges();
                    break;
            }
            return RedirectToAction("TopicIndex");
        }
        public FileContentResult GetImage(int id)
        {
            var topic = db.Topics.FirstOrDefault(m => m.TopicId == id);

            if (topic != null)
            {
                return File(topic.Picture, topic.PictureMimeType);
            }
            return null;
        }
        #endregion

        #region Article
        public ActionResult ArticleIndex(int page = 1)
        {
            ArticleVM articleVM = new ArticleVM
            {
                Articles = db.Articles
                    .OrderBy(a => a.ArticleId)
                    .Skip((page - 1) * ARTICLE_PAGE_SIZE)
                    .Take(ARTICLE_PAGE_SIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = ARTICLE_PAGE_SIZE,
                    TotalItems = db.Articles.Count()
                }
            };
            return View(articleVM);
        }

        public ActionResult ArticleCreate()
        {
            var article = new Article
            {
                ArticleId = (db.Articles.Count() == 0) ? 0 : db.Articles.Max(a => a.ArticleId) + 1,
                PostTime = DateTime.Now
            };
            ViewBag.TopicSelectList = new SelectList(db.Topics, "TopicId", "Name");
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleCreate([Bind(Include = "ArticleId,ShowFlag,TopicId,Title,Content,PostTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("ArticleIndex");
            }
            return View(article);
        }

        public ActionResult ArticleEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicSelectList = new SelectList(db.Topics, "TopicId", "Name");
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleEdit([Bind(Include = "ArticleId,ShowFlag,TopicId,Title,Content,PostTime")] Article article, string submit)
        {
            switch (submit)
            {
                case "Save":
                    if (ModelState.IsValid)
                    {
                        db.Entry(article).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    break;
                case "Delete":
                    article = db.Articles.Find(article.ArticleId);
                    db.Articles.Remove(article);
                    db.SaveChanges();
                    break;
            }
            return RedirectToAction("ArticleIndex");
        }
        #endregion

        #region  Keyword
        public ActionResult KeywordCreate(int id)
        {
            var keyword = new Keyword
            {
                KeywordId = (db.Keywords.Count() == 0) ? 0 : db.Keywords.Max(k => k.KeywordId) + 1,
                ArticleId = id
            };

            return View(keyword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KeywordCreate([Bind(Include = "KeywordId,ArticleId,Content")] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                db.Keywords.Add(keyword);
                db.SaveChanges();
            }
            return RedirectToAction("ArticleEdit", new { id = keyword.ArticleId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KeywordEdit([Bind(Include = "KeywordId,ArticleId,Content")] Keyword keyword, string submit)
        {
            switch (submit)
            {
                case "Save":
                    if (ModelState.IsValid)
                    {
                        db.Entry(keyword).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    break;
                case "Delete":
                    keyword = db.Keywords.Find(keyword.KeywordId);
                    db.Keywords.Remove(keyword);
                    db.SaveChanges();
                    break;
                }
            return RedirectToAction("ArticleEdit", new { id = keyword.ArticleId });
        }
        #endregion

        #region Comment
        [ActionName("CommentDelete")]
        public ActionResult CommentDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();

            return RedirectToAction("ArticleEdit", new { id = comment.ArticleId });
        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}