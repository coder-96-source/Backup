using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSurfer.Web.Models;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetSurfer.Web.Helpers;
using System.Linq;

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

                var entityModel = await this._unitOfWork.ArticleRepository
                    .GetArticleAsync(id);

                if (entityModel == null)
                {
                    return NotFound();
                }

                // Increase read count
                await this._unitOfWork.ArticleRepository.IncreaseArticleReadCountAsync(id);
                await this._unitOfWork.ArticleRepository.SaveAsync();

                article = entityModel.MapToDomain();
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

                var entityModels = IsAdministrator()
                    ? await this._unitOfWork
                        .ArticleRepository.GetArticlesByUserIdAsync()
                    : await this._unitOfWork
                        .ArticleRepository.GetArticlesByUserIdAsync(userId); // Restrict by userId

                articles = entityModels?.Select(a => a.MapToDomain());
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
                var entityModels = await this._unitOfWork
                    .ArticleRepository
                    .GetArticlesByPageAsync(pageId, itemPerPage);

                articles = entityModels?.Select(a => a.MapToDomain());
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
                var entityModels = await this._unitOfWork
                    .ArticleRepository
                    .GetTopArticlesAsync(item);

                articles = entityModels?.Select(a => a.MapToDomain());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetArticlesByPage));
            }

            return articles;
        }
    }
}