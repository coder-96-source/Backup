using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class ArticlesController : BaseController
    {
        public ArticlesController(IUnitOfWork unitOfWork, ILogger<ArticlesController> logger) 
            : base(unitOfWork, logger)
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

                article = await this._unitOfWork
                    .ArticleRepository.GetArticleAsync(id);

                if (article == null)
                {
                    return NotFound();
                }

                // Increase read count
                await this._unitOfWork.ArticleRepository.IncreaseArticleReadCountAsync(id);
                await this._unitOfWork.ArticleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticle));
            }

            return Ok(article);
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public async Task<IEnumerable<Article>> GetArticlesByUserIdAsync([FromRoute] int userId)
        {
            IEnumerable<Article> articles = null;

            try
            {
                bool isUserExist = await this._unitOfWork.UserRepository.IsUserExistAsync(userId);
                if (!isUserExist)
                {
                    return null;
                }

                articles = IsAdministrator()
                    ? await this._unitOfWork
                        .ArticleRepository.GetArticlesByUserIdAsync()
                    : await this._unitOfWork
                        .ArticleRepository.GetArticlesByUserIdAsync(userId); // Restrict by userId
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByUserIdAsync));
            }

            return articles;
        }

        [HttpGet("page/{pageId?}")]
        public async Task<IEnumerable<Article>> GetArticlesByPage(int pageId = 1)
        {
            const int itemPerPage = 3;
            IEnumerable<Article> articles = null;

            try
            {
                articles = await this._unitOfWork
                    .ArticleRepository
                    .GetArticlesByPageAsync(pageId, itemPerPage);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return articles;
        }

        [HttpGet("top/{item?}")]
        public async Task<IEnumerable<Article>> GetTopArticles(int item = 3)
        {
            IEnumerable<Article> articles = null;

            try
            {
                articles = await this._unitOfWork
                    .ArticleRepository
                    .GetTopArticlesAsync(item);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return articles;
        }
    }
}