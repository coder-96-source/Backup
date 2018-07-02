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
    public class TopicsController : BaseController
    {
        public TopicsController(JKBlogDbContext context, ILogger<TopicsController> logger)
            : base(context, logger)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopic([FromRoute] int id)
        {
            Base64Topic base64Topic = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var topic = await this._context.Topics
                    .Include(t => t.User)
                    .SingleOrDefaultAsync(t => t.TopicId == id);
                if (topic == null)
                {
                    return NotFound();
                }

                base64Topic = ModelConverter.ConvertBinaryModelsToBase64Models
                    (topic, _base64TopicType.Value, _targetPropertyNames.Value) as Base64Topic;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopic));
            }

            return Ok(base64Topic);
        }

        [HttpGet]
        public IEnumerable<Base64Topic> GetTopics()
        {
            IEnumerable<Base64Topic> base64Topics = null;

            try
            {
                var topics = this._context.Topics.ToArray();
                base64Topics = ModelConverter.ConvertBinaryModelsToBase64Models
                    (topics, _base64TopicType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Topic>;

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopics));
            }

            return base64Topics;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public IEnumerable<Base64Topic> GetTopicsByUserId([FromRoute] int userId)
        {
            IEnumerable<Base64Topic> base64Topics = null;

            try
            {
                bool isUserExist = this._context.Users.Any(u => u.UserId == userId);
                if (!isUserExist)
                {
                    return null;
                }

                var topics = IsAdministrator() 
                    ? this._context.Topics.ToArray() 
                    : this._context.Topics.Where(a => a.UserId == userId).ToArray();

                base64Topics = ModelConverter.ConvertBinaryModelsToBase64Models
                      (topics, _base64TopicType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Topic>;

                foreach (var topic in base64Topics)
                {
                    ClearSensitiveUserInformation(topic.User);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopicsByUserId));
            }

            return base64Topics;
        }
    }
}