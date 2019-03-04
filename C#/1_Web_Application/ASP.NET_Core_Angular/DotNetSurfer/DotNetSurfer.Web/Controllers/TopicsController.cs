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
    public class TopicsController : BaseController
    {
        public TopicsController(IUnitOfWork unitOfWork, ILogger<TopicsController> logger)
            : base(unitOfWork, logger)
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

                topic = await this._unitOfWork.TopicRepository.GetTopicAsync(id);

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
        public async Task<IEnumerable<Topic>> GetTopics()
        {
            IEnumerable<Topic> topics = null;

            try
            {
                topics = await this._unitOfWork.TopicRepository.GetTopicsAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopics));
            }

            return topics;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public async Task<IEnumerable<Topic>> GetTopicsByUserId([FromRoute] int userId)
        {
            IEnumerable<Topic> topics = null;

            try
            {
                bool isUserExist = await this._unitOfWork.UserRepository.IsUserExistAsync(userId);
                if (!isUserExist)
                {
                    return null;
                }

                topics = IsAdministrator()
                    ? await this._unitOfWork.TopicRepository.GetTopicsByUserIdAsync()
                    : await this._unitOfWork.TopicRepository.GetTopicsByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetTopicsByUserId));
            }

            return topics;
        }
    }
}