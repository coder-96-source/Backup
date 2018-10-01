using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
    public class AdminController : BaseController
    {
        public AdminController(DotNetSurferDbContext context, ILogger<AdminController> logger)
            : base(context, logger)
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

                this._context.Entry(topic).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
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

                bool isTitleExist = this._context.Topics.Any(t => t.Title == topic.Title);
                if (isTitleExist)
                {
                    return BadRequest("Title already exists");
                }

                this._context.Topics.Add(topic);
                await this._context.SaveChangesAsync();
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

                topic = await this._context.Topics
                    .Include(t => t.User)
                    .SingleOrDefaultAsync(t => t.TopicId == id);
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

                this._context.Topics.Remove(topic);
                await this._context.SaveChangesAsync();
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
                this._context.Entry(article).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
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

                this._context.Articles.Add(article);
                await this._context.SaveChangesAsync();
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

                article = await this._context.Articles.SingleOrDefaultAsync(t => t.ArticleId == id);
                if (article == null)
                {
                    return NotFound();
                }

                this._context.Articles.Remove(article);
                await this._context.SaveChangesAsync();
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
                this._context.Entry(announcement).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
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

                this._context.Announcements.Add(announcement);
                await this._context.SaveChangesAsync();
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

                announcement = await this._context.Announcements.SingleOrDefaultAsync(m => m.AnnouncementId == id);
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

                this._context.Announcements.Remove(announcement);
                await this._context.SaveChangesAsync();
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

                var currentUser = this._context.Users.AsNoTracking(). // To avoid context tracking exception
                    FirstOrDefault(u => u.UserId == user.UserId);
                if (!IsPasswordCorrect(currentUser.Password, user.Password))
                {
                    return Unauthorized();
                }

                // Email check, if there is already an email trying to change
                bool isAlreadyEmailExists = currentUser.Email != user.Email
                    && IsUserEmailExists(user.Email);
                if (isAlreadyEmailExists)
                {
                    return BadRequest("User email already exists");
                }

                user.Password = _encryptor.Value.Encrypt(user.Password);
                this._context.Entry(user).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
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