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
    [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
    public class AdminController : BaseController
    {
        public AdminController(JKBlogDbContext context, ILogger<AdminController> logger)
            : base(context, logger)
        {

        }

        #region Topics
        [HttpPut("topics/{id}")]
        public async Task<IActionResult> UpdateTopic([FromRoute] int id, [FromBody] Base64Topic base64Topic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != base64Topic.TopicId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && base64Topic.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                var topic = ModelConverter.ConvertBase64ModelsToBinaryModels
                    (base64Topic, _binaryTopicType.Value, _targetPropertyNames.Value) as Topic;
                topic.ModifyDate = DateTime.Now;

                this._context.Entry(topic).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateTopic));
                return BadRequest(ex.Message);
            }
            
            return Ok(base64Topic);
        }

        [HttpPost("topics")]
        public async Task<IActionResult> CreateTopic([FromBody] Base64Topic base64Topic)
        {
            try
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

                this._context.Topics.Add(topic);
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(CreateTopic));
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(Topic), new { id = base64Topic.TopicId }, base64Topic);
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
        public async Task<IActionResult> UpdateArticle([FromRoute] int id, [FromBody] Base64Article base64Article)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != base64Article.ArticleId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && base64Article.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                var article = ModelConverter.ConvertBase64ModelsToBinaryModels
                    (base64Article, _binaryArticleType.Value, _targetPropertyNames.Value) as Article;
                article.ModifyDate = DateTime.Now;

                this._context.Entry(article).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateArticle));
                return BadRequest(ex.Message);
            }         

            return Ok(base64Article);
        }

        [HttpPost("articles")]
        public async Task<IActionResult> CreateArticle([FromBody] Base64Article base64Article)
        {
            Article article = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                article = ModelConverter.ConvertBase64ModelsToBinaryModels
                   (base64Article, _binaryArticleType.Value, _targetPropertyNames.Value) as Article;

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
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] Base64User base64User)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != base64User.UserId)
                {
                    return BadRequest();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && base64User.UserId != userId.Value)
                {
                    return Unauthorized();
                }

                var currentUser = this._context.Users.AsNoTracking(). // To avoid context tracking exception
                    FirstOrDefault(u => u.UserId == base64User.UserId);
                if (!IsPasswordCorrect(currentUser.Password, base64User.Password))
                {
                    return Unauthorized();
                }

                // Email check, if there is already an email trying to change
                bool isAlreadyEmailExists = currentUser.Email != base64User.Email
                    && IsUserEmailExists(base64User.Email);
                if (isAlreadyEmailExists)
                {
                    return BadRequest("User email already exists");
                }

                var user = ModelConverter.ConvertBase64ModelsToBinaryModels
                    (base64User, _binaryUserType.Value, _targetPropertyNames.Value) as User;
                user.Password = _encryptor.Value.Encrypt(user.Password);

                this._context.Entry(user).State = EntityState.Modified;

                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(UpdateUser));
            }

            return Ok(base64User);
        }
        #endregion
    }
}