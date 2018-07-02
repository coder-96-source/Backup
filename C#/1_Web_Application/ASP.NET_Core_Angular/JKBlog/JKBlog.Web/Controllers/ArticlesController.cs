using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JKBlog.Helpers.ModelConverters;
using JKBlog.Models.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JKBlog.Controllers
{
    public class ArticlesController : BaseController
    {
        public ArticlesController(JKBlogDbContext context, ILogger<ArticlesController> logger) 
            : base(context, logger)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            Base64Article base64Article = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var article = await this._context.Articles
                    .Include(a => a.User)
                    .Include(a => a.Topic)
                    .Include(a => a.Tags)
                    .SingleOrDefaultAsync(a => a.ArticleId == id);

                if (article == null)
                {
                    return NotFound();
                }

                // Increase read count and update
                article.ReadCount++;
                this._context.Entry(article).State = EntityState.Modified;
                await this._context.SaveChangesAsync();

                base64Article = ModelConverter.ConvertBinaryModelsToBase64Models
                    (article, _base64ArticleType.Value, _targetPropertyNames.Value) as Base64Article;

                ClearSensitiveUserInformation(base64Article.User);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticle));
            }

            return Ok(base64Article);
        }

        [HttpGet]
        public IEnumerable<Base64Article> GetArticles()
        {
            IEnumerable<Base64Article> base64Articles = null;

            try
            {
                var articles = this._context.Articles
                    .Include(article => article.User)
                    .Include(article => article.Topic)
                    .Include(a => a.Tags)
                    .Where(a => a.ShowFlag == true)
                    .ToArray();

                base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
                    (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

                foreach (var article in base64Articles)
                {
                    ClearSensitiveUserInformation(article.User);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticles));
            }

            return base64Articles;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]

        public IEnumerable<Base64Article> GetArticlesByUserId([FromRoute] int userId)
        {
            IEnumerable<Base64Article> base64Articles = null;

            try
            {
                bool isUserExist = this._context.Users.Any(u => u.UserId == userId);
                if (!isUserExist)
                {
                    return null;
                }

                var articles = IsAdministrator()
                    ? this._context.Articles
                    .Include(a => a.User)
                    .Include(a => a.Topic)
                    .ToArray()
                    : this._context.Articles
                    .Include(a => a.User)
                    .Include(a => a.Topic)
                    .Where(a => a.UserId == userId)
                    .ToArray();

                base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
                    (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

                foreach (var article in base64Articles)
                {
                    ClearSensitiveUserInformation(article.User);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByUserId));
            }

            return base64Articles;
        }

        [HttpGet("page/{page?}")]
        public IEnumerable<Base64Article> GetArticlesByPage(int page = 1)
        {
            const int itemPerPage = 3;
            IEnumerable<Base64Article> base64Articles = null;

            try
            {
                var articles = this._context.Articles
                    .Include(article => article.User)
                    .Include(article => article.Topic)
                    .Include(a => a.Tags)
                    .Where(a => a.ShowFlag == true)
                    .OrderByDescending(a => a.PostDate)
                    .Skip((page - 1) * itemPerPage)
                    .Take(itemPerPage)
                    .ToArray();

                base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
                    (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

                foreach (var article in base64Articles)
                {
                    ClearSensitiveUserInformation(article.User);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return base64Articles;
        }
    }
}