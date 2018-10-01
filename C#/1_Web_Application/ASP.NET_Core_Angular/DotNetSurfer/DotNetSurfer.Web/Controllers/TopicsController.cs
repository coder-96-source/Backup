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
    public class TopicsController : BaseController
    {
        public TopicsController(DotNetSurferDbContext context, ILogger<TopicsController> logger)
            : base(context, logger)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopic([FromRoute] int id)
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
                    .AsNoTracking()
                    .SingleOrDefaultAsync(t => t.TopicId == id);

                if (topic == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopic));
            }

            return Ok(topic);
        }

        [HttpGet]
        public IEnumerable<Topic> GetTopics()
        {
            IEnumerable<Topic> topics = null;

            try
            {
                topics = this._context.Topics
                    .AsNoTracking();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopics));
            }

            return topics;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public IEnumerable<Topic> GetTopicsByUserId([FromRoute] int userId)
        {
            IEnumerable<Topic> topics = null;

            try
            {
                bool isUserExist = this._context.Users
                    .Any(u => u.UserId == userId);
                if (!isUserExist)
                {
                    return null;
                }

                topics = IsAdministrator() 
                    ? this._context.Topics
                        .AsNoTracking()
                    : this._context.Topics
                        .Where(a => a.UserId == userId)
                        .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopicsByUserId));
            }

            return topics;
        }
    }
}