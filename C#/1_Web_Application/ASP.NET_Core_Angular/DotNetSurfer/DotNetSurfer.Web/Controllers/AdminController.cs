using System;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
    public class AdminController : BaseController
    {
        public AdminController(IUnitOfWork unitOfWork, ILogger<AdminController> logger)
            : base(unitOfWork, logger)
        {
 
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

                this._unitOfWork.TopicRepository.Update(topic);
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

                this._unitOfWork.TopicRepository.Create(topic);
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
            Topic topic = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                topic = await this._unitOfWork.TopicRepository.GetTopicAsync(id);
                if (topic == null)
                {
                    return NotFound();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && topic.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                this._unitOfWork.TopicRepository.Delete(topic);
                await this._unitOfWork.TopicRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteTopic));
                return BadRequest(ex.Message);
            }

            return Ok(topic);
        }
        #endregion

        #region Articles
        [HttpPut("articles/{id}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] int id, [FromBody] DotNetSurfer.DAL.Entities.Article article)
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

                this._unitOfWork.ArticleRepository.Update(article);
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
        public async Task<IActionResult> CreateArticle([FromBody] DotNetSurfer.DAL.Entities.Article article)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this._unitOfWork.ArticleRepository.Create(article);
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
            Article article = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                article = await this._unitOfWork.ArticleRepository.GetArticleAsync(id);
                if (article == null)
                {
                    return NotFound();
                }

                this._unitOfWork.ArticleRepository.Delete(article);
                await this._unitOfWork.ArticleRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteArticle));
                return BadRequest(ex.Message);
            }

            return Ok(article);
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

                this._unitOfWork.AnnouncementRepository.Update(announcement);
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

                this._unitOfWork.AnnouncementRepository.Create(announcement);
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
            Announcement announcement = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                announcement = await this._unitOfWork.AnnouncementRepository.GetAnnouncementAsync(id);
                if (announcement == null)
                {
                    return NotFound();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && announcement.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                this._unitOfWork.AnnouncementRepository.Delete(announcement);
                await this._unitOfWork.AnnouncementRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(DeleteAnnouncement));
                return BadRequest(ex.Message);
            }

            return Ok(announcement);
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
                if (!IsPasswordCorrect(currentUser.Password, user.Password))
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

                user.Password = _encryptor.Value.Encrypt(user.Password);
                this._unitOfWork.UserRepository.Update(user);
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