using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;
using JKBlog.Helpers.ModelConverters;
using Microsoft.EntityFrameworkCore;

namespace JKBlog.Controllers
{
    [Produces("application/json")]
    public abstract class BaseApiController : Controller
    {
        protected static readonly Lazy<Type> _binaryTopicType = new Lazy<Type>(() => typeof(Topic));
        protected static readonly Lazy<Type> _binaryArticleType = new Lazy<Type>(() => typeof(Article));
        protected static readonly Lazy<Type> _base64TopicType = new Lazy<Type>(() => typeof(Base64Topic));
        protected static readonly Lazy<Type> _base64ArticleType = new Lazy<Type>(() => typeof(Base64Article));
        protected static readonly Lazy<List<string>> _targetPropertyNames = new Lazy<List<string>>(() => {
            return new List<string>() { "Picture" };
        }); // binary, base64 property names

        protected readonly JKBlogDbContext _context;

        public BaseApiController(JKBlogDbContext context)
        {
            this._context = context;
        }

        #region Topic
        [HttpGet("{id}")]
        public async Task<IActionResult> Topic([FromRoute] int id)
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

            var base64Topic = ModelConverter.ConvertBinaryModelsToBase64Models
                (topic, _base64TopicType.Value, _targetPropertyNames.Value) as Base64Topic;

            return Ok(base64Topic);
        }

        [HttpGet]
        //[Route("api/[controller]/[action]")]
        public IEnumerable<Base64Topic> Topics()
        {
            var topics = this._context.Topics.ToArray();
            var base64Topics = ModelConverter.ConvertBinaryModelsToBase64Models
                (topics, _base64TopicType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Topic>;

            return base64Topics;
        }

        protected bool IsTopicExists(int id)
        {
            return this._context.Topics.Any(t => t.TopicId == id);
        }
        #endregion

        #region Article
        [HttpGet("{id}")]
        //[Route("api/[controller]/[action]")]
        public async Task<IActionResult> Article([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await this._context.Articles
                .Include(a => a.User)
                .Include(a => a.Topic)
                .SingleOrDefaultAsync(a => a.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            var base64Article = ModelConverter.ConvertBinaryModelsToBase64Models
                (article, _base64ArticleType.Value, _targetPropertyNames.Value) as Base64Article;

            ClearSensitiveUserInformation(base64Article.User);

            return Ok(base64Article);
        }

        [HttpGet]
        //[Route("api/[controller]/[action]")]
        public IEnumerable<Base64Article> Articles()
        {
            var articles = this._context.Articles
                .Include(article => article.User)
                .Include(article => article.Topic)
                .ToArray();

            var base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
                (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

            foreach (var article in base64Articles)
            {
                ClearSensitiveUserInformation(article.User);
            }

            return base64Articles;
        }
      
        protected bool IsArticleExists(int id)
        {
            return this._context.Articles.Any(t => t.ArticleId == id);
        }
        #endregion

        #region Announcement
        [HttpGet("{id}")]
        //[Route("api/[controller]/[action]")]
        public async Task<IActionResult> Announcement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var announcement = await this._context.Announcements
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.AnnouncementId == id);

            if (announcement == null)
            {
                return NotFound();
            }

            ClearSensitiveUserInformation(announcement.User);

            return Ok(announcement);
        }

        [HttpGet]
        //[Route("api/[controller]/[action]")]
        public IEnumerable<Announcement> Announcements()
        {
            var announcements = this._context.Announcements
                .Include(announcement => announcement.User)
                .ToList();

            foreach(var announcement in announcements)
            {
                ClearSensitiveUserInformation(announcement.User);
            }

            return announcements;
        }
        
        protected bool IsAnnouncementExists(int id)
        {
            return this._context.Announcements.Any(a => a.AnnouncementId == id);
        }
        #endregion

        private void ClearSensitiveUserInformation(User user)
        {
            user.Password = null;
        }
    }
}
