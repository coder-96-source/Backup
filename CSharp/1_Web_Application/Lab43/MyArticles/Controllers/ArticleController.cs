using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyArticles.Models;
using MyArticles.HtmlHelpers.Encrypt;

namespace MyArticles.Controllers
{
    public class ArticleController : Controller
    {
        private const int PAGE_SIZE = 10; // 10 articles per page
        private EFDbContext db = new EFDbContext();

        #region Article
        public ActionResult Index(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ArticleVM articleVM = new ArticleVM
            {
                Articles = db.Articles
                    .Where(t => (t.TopicId == id) && (t.ShowFlag != false))
                    .OrderBy(a => a.ArticleId)
                    .Skip((page - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = db.Articles.Count()
                },
                SelectList = new SelectList(db.Topics.Where(t => !(t.TopicId == id)), "TopicId", "Name"), // 선택된 Topic 제외
                CurrentTopic = db.Topics.Find(id).Name
            };
            return View(articleVM);
        }

        public ActionResult View(int? id)
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
            return View(article);
        }
        #endregion

        #region Comment
        public ActionResult CommentCreate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = new Comment
            {
                CommentId = (db.Comments.Count() == 0) ? 0 : db.Comments.Max(c => c.CommentId) + 1,
                ArticleId = (int)id,
                PostTime = DateTime.Now
            };
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentCreate([Bind(Include = "CommentId,ArticleId,Content,CommentPassword,PostTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                IEncryptable encryptor = new HashEncryption();
                comment.CommentPassword = encryptor.Encrypt(comment.CommentPassword);
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return RedirectToAction("View", new { id = comment.ArticleId });
        }

        [HttpPost, ActionName("CommentDelete")]
        public ActionResult CommentDeleteConfirmed(int commentId, string password)
        {

            var comment = db.Comments.Find(commentId);
            IEncryptable encryptor = new HashEncryption();
            bool passwordVaild = encryptor.IsEqual(password, comment.CommentPassword);

            if (passwordVaild)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
                return Json("Comment has been deleted successfully!");
            }
            return Json("Wrong password!");
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
