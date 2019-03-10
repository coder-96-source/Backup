using System;
using System.Threading.Tasks;
using DotNetSurfer.Core.Encryptors;
using DotNetSurfer.Web.Models;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetSurfer.Web.Helpers;

namespace DotNetSurfer.Web.Controllers
{
    [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
    public class AdminController : BaseController
    {
        private readonly IEncryptor _encryptor;

        public AdminController(IUnitOfWork unitOfWork, IEncryptor encryptor, ILogger<AdminController> logger)
            : base(unitOfWork, logger)
        {
            this._encryptor = encryptor;
        }

        #region Topics
        [HttpPut("topics/{id}")]
        public async Task<IActionResult> UpdateTopic([FromRoute] int id, [FromBody] Topic topic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != topic.TopicId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && topic.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                topic.ModifyDate = DateTime.Now;

                this._unitOfWork.TopicRepository.Update(topic.MapToEntity());
                await this._unitOfWork.TopicRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateTopic));
                return BadRequest(ex.Message);
            }
            
            return Ok(topic);
        }

        [HttpPost("topics")]
        public async Task<IActionResult> CreateTopic([FromBody] Topic topic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isTitleExist = await this._unitOfWork.TopicRepository.IsTitleExistAsync(topic.Title);
                if (isTitleExist)
                {
                    return BadRequest("Title already exists");
                }

                this._unitOfWork.TopicRepository.Create(topic.MapToEntity());
                await this._unitOfWork.TopicRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(CreateTopic));
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(Topic), new { id = topic.TopicId }, topic);
        }

        [HttpDelete("topics/{id}")]
        public async Task<IActionResult> DeleteTopic([FromRoute] int id)
        {
            DAL.Entities.Topic entityModel = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                entityModel = await this._unitOfWork.TopicRepository.GetTopicAsync(id);
                if (entityModel == null)
                {
                    return NotFound();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && entityModel.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                this._unitOfWork.TopicRepository.Delete(entityModel);
                await this._unitOfWork.TopicRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteTopic));
                return BadRequest(ex.Message);
            }

            return Ok(entityModel);
        }
        #endregion

        #region Articles
        [HttpPut("articles/{id}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] int id, [FromBody] Article article)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != article.ArticleId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && article.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                article.ModifyDate = DateTime.Now;

                this._unitOfWork.ArticleRepository.Update(article.MapToEntity());
                await this._unitOfWork.ArticleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateArticle));
                return BadRequest(ex.Message);
            }         

            return Ok(article);
        }

        [HttpPost("articles")]
        public async Task<IActionResult> CreateArticle([FromBody] Article article)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this._unitOfWork.ArticleRepository.Create(article.MapToEntity());
                await this._unitOfWork.ArticleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(CreateArticle));
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(Article), new { id = article.ArticleId }, article);
        }

        [HttpDelete("articles/{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            DAL.Entities.Article entityModel = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                entityModel = await this._unitOfWork.ArticleRepository.GetArticleAsync(id);
                if (entityModel == null)
                {
                    return NotFound();
                }

                this._unitOfWork.ArticleRepository.Delete(entityModel);
                await this._unitOfWork.ArticleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteArticle));
                return BadRequest(ex.Message);
            }

            return Ok(entityModel);
        }
        #endregion

        #region Announcements
        [HttpPut("announcements/{id}")]
        public async Task<IActionResult> UpdateAnnouncement([FromRoute] int id, [FromBody] Announcement announcement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != announcement.AnnouncementId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && announcement.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                announcement.ModifyDate = DateTime.Now;

                this._unitOfWork.AnnouncementRepository.Update(announcement.MapToEntity());
                await this._unitOfWork.AnnouncementRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateAnnouncement));
                return BadRequest(ex.Message);
            }

            return Ok(announcement);
        }

        [HttpPost("announcements")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this._unitOfWork.AnnouncementRepository.Create(announcement.MapToEntity());
                await this._unitOfWork.AnnouncementRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(CreateAnnouncement));
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(Announcement), new { id = announcement.AnnouncementId }, announcement);
        }

        [HttpDelete("announcements/{id}")]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] int id)
        {
            DAL.Entities.Announcement entityModel = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                entityModel = await this._unitOfWork.AnnouncementRepository.GetAnnouncementAsync(id);
                if (entityModel == null)
                {
                    return NotFound();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && entityModel.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                this._unitOfWork.AnnouncementRepository.Delete(entityModel);
                await this._unitOfWork.AnnouncementRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteAnnouncement));
                return BadRequest(ex.Message);
            }

            return Ok(entityModel);
        }
        #endregion

        #region Users
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != user.UserId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && user.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                var currentUser = await this._unitOfWork.UserRepository.GetUserAsNoTrackingAsync(id); // To avoid context tracking exception
                if (!this._encryptor.IsEqual(user.Password, currentUser.Password))
                {
                    return Unauthorized();
                }

                // Email check, if there is already an email trying to change
                bool isUserEmailExist = await this._unitOfWork.UserRepository.IsEmailExistAsync(user.Email);
                bool isAlreadyEmailExists = currentUser.Email != user.Email
                    && isUserEmailExist;
                if (isAlreadyEmailExists)
                {
                    return BadRequest("User email already exists");
                }

                user.Password = _encryptor.Encrypt(user.Password);

                this._unitOfWork.UserRepository.Update(user.MapToEntity());
                await this._unitOfWork.UserRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateUser));
            }

            return Ok(user);
        }
        #endregion
    }
}