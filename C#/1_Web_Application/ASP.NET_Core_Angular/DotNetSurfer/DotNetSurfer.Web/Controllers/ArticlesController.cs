using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class ArticlesController : BaseController
    {
        public ArticlesController(DotNetSurferDbContext context, ILogger<ArticlesController> logger) 
            : base(context, logger)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            Article article = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                article = await this._context.Articles
                    .Include(a => a.User)
                    .Include(a => a.Topic)
                    .Include(a => a.Tags)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(a => a.ArticleId == id);

                if (article == null)
                {
                    return NotFound();
                }

                // Increase read count and update
                article.ReadCount++;
                this._context.Entry(article).State = EntityState.Modified;
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticle));
            }

            return Ok(article);
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public IEnumerable<Article> GetArticlesByUserId([FromRoute] int userId)
        {
            IEnumerable<Article> articles = null;

            try
            {
                bool isUserExist = this._context.Users.Any(u => u.UserId == userId);
                if (!isUserExist)
                {
                    return null;
                }

                articles = IsAdministrator()
                    ? this._context.Articles
                    .Include(a => a.User)
                    .AsNoTracking()
                    : this._context.Articles
                    .Include(a => a.User)
                    .Where(a => a.UserId == userId)
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByUserId));
            }

            return articles;
        }

        [HttpGet("page/{pageId?}")]
        public IEnumerable<Article> GetArticlesByPage(int pageId = 1)
        {
            const int itemPerPage = 3;
            IEnumerable<Article> articles = null;

            try
            {
                articles = this._context.Articles
                    .Include(article => article.User)
                    .Include(article => article.Topic)
                    .Where(a => a.ShowFlag)
                    .OrderByDescending(article => article.PostDate)
                    .Skip((pageId - 1) * itemPerPage)
                    .Take(itemPerPage)
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return articles;
        }

        [HttpGet("top/{item?}")]
        public IEnumerable<Article> GetTopArticles(int item = 3)
        {
            IEnumerable<Article> articles = null;

            try
            {
                articles = this._context.Articles
                    .Include(article => article.User)
                    .Where(article => article.ShowFlag)
                    .OrderByDescending(a => a.ReadCount)
                    .Take(item)
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return articles;
        }
    }
}