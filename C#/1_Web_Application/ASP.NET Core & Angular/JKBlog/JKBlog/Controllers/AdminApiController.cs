using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JKBlog.Helpers.ModelConverters;

namespace JKBlog.Controllers
{
    [Authorize]
    //[Produces("application/json")]
    [Route("api/Admin/[action]")]
    public class AdminApiController : BaseApiController
    {
        public AdminApiController(JKBlogDbContext context) : base(context)
        {
 
        }

        #region Topic
        //[HttpGet]
        //public IEnumerable<Base64Topic> Topics()
        //{
        //    var topics = this._context.Topics.ToArray();
        //    var base64Topics = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (topics, _base64TopicType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Topic>;

        //    return base64Topics;
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Topic([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var topic = await this._context.Topics.SingleOrDefaultAsync(t => t.TopicId == id);
        //    if (topic == null)
        //    {
        //        return NotFound();
        //    }

        //    var base64Topic = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (topic, _base64TopicType.Value, _targetPropertyNames.Value) as Base64Topic;

        //    return Ok(base64Topic);
        //}

        [HttpPut("{id}")]
        [ActionName("Topic/Update")]
        public async Task<IActionResult> UpdateTopic([FromRoute] int id, [FromBody] Base64Topic base64Topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != base64Topic.TopicId)
            {
                return BadRequest();
            }

            var topic = ModelConverter.ConvertBase64ModelsToBinaryModels
                (base64Topic, _binaryTopicType.Value, _targetPropertyNames.Value) as Topic;


            this._context.Entry(topic).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsTopicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(base64Topic);
        }

        [HttpPost]
        [ActionName("Topic/Create")]
        public async Task<IActionResult> CreateTopic([FromBody] Base64Topic base64Topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isTitleExist = this._context.Topics.Any(t => t.Title == base64Topic.Title);
            if (isTitleExist)
            {
                return BadRequest("Title already exists");
            }

            var topic = ModelConverter.ConvertBase64ModelsToBinaryModels
                (base64Topic, _binaryTopicType.Value, _targetPropertyNames.Value) as Topic; 

            // Set default properties
            topic.ModifyDate = DateTime.Now;

            this._context.Topics.Add(topic);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Topic), new { id = topic.TopicId }, topic);
        }

        [HttpDelete("{id}")]
        [ActionName("Topic/Delete")]
        public async Task<IActionResult> DeleteTopic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topic = await this._context.Topics.SingleOrDefaultAsync(t => t.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }

            this._context.Topics.Remove(topic);
            await this._context.SaveChangesAsync();

            return Ok(topic);
        }

        //private bool IsTopicExists(int id)
        //{
        //    return this._context.Topics.Any(t => t.TopicId == id);
        //}
        #endregion

        #region Article
        //[HttpGet]
        //public IEnumerable<Base64Article> Articles()
        //{
        //    var articles = this._context.Articles.ToArray();
        //    var base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

        //    return base64Articles;
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Article([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var article = await this._context.Articles.SingleOrDefaultAsync(t => t.ArticleId == id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    var base64Article = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (article, _base64ArticleType.Value, _targetPropertyNames.Value) as Base64Article;

        //    return Ok(base64Article);
        //}

        [HttpPut("{id}")]
        [ActionName("Article/Update")]
        public async Task<IActionResult> UpdateArticle([FromRoute] int id, [FromBody] Base64Article base64Article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != base64Article.ArticleId)
            {
                return BadRequest();
            }

            var article = ModelConverter.ConvertBase64ModelsToBinaryModels
                (base64Article, _binaryArticleType.Value, _targetPropertyNames.Value) as Article;

            this._context.Entry(article).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(base64Article);
        }

        [HttpPost]
        [ActionName("Article/Create")]
        public async Task<IActionResult> CreateArticle([FromBody] Base64Article base64Article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = ModelConverter.ConvertBase64ModelsToBinaryModels
               (base64Article, _binaryArticleType.Value, _targetPropertyNames.Value) as Article;

            // Set default properties
            int contentDisplayLength = 50; // length to display
            article.ContentDisplay = article.Content.Length > contentDisplayLength
                ? article.Content.Substring(0, contentDisplayLength - 1)
                : article.Content.Substring(0, article.Content.Length);
            article.ModifyDate = DateTime.Now;

            this._context.Articles.Add(article);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Article), new { id = article.ArticleId }, article);
        }

        [HttpDelete("{id}")]
        [ActionName("Article/Delete")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await this._context.Articles.SingleOrDefaultAsync(t => t.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            this._context.Articles.Remove(article);
            await this._context.SaveChangesAsync();

            return Ok(article);
        }

        //private bool IsArticleExists(int id)
        //{
        //    return this._context.Articles.Any(t => t.ArticleId == id);
        //}
        #endregion

        #region Announcement
        //[HttpGet]
        //public IEnumerable<Announcement> Announcements()
        //{
        //    var announcements = this._context.Announcements
        //        .Include(announcement => announcement.User)
        //        .ToList();

        //    return announcements;
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Announcement([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var announcement = await this._context.Announcements
        //        .Include(a => a.User)
        //        .SingleOrDefaultAsync(a => a.AnnouncementId == id);

        //    if (announcement == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(announcement);
        //}

        [HttpPut("{id}")]
        [ActionName("Announcement/Update")]
        public async Task<IActionResult> UpdateAnnouncement([FromRoute] int id, [FromBody] Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.AnnouncementId)
            {
                return BadRequest();
            }

            this._context.Entry(announcement).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsAnnouncementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [ActionName("Announcement/Create")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            // user check and mapping
            bool IsUserExist = this._context.Users.Any(u => u.UserId == announcement.UserId);
            if (IsUserExist)
            {
                var user = this._context.Users.FirstOrDefault(u => u.UserId == announcement.UserId);
                announcement.User = user;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            announcement.ModifyDate = DateTime.Now;

            this._context.Announcements.Add(announcement);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Announcement), new { id = announcement.AnnouncementId }, announcement);
        }

        [HttpDelete("{id}")]
        [ActionName("Announcement/Delete")]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var announcement = await this._context.Announcements.SingleOrDefaultAsync(m => m.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            this._context.Announcements.Remove(announcement);
            await this._context.SaveChangesAsync();

            return Ok(announcement);
        }

        //private bool IsAnnouncementExists(int id)
        //{
        //    return this._context.Announcements.Any(a => a.AnnouncementId == id);
        //}
        #endregion
    }
}