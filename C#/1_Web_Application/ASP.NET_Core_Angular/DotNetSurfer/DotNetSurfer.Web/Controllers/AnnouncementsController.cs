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
    public class AnnouncementsController : BaseController
    {
        public AnnouncementsController(IUnitOfWork unitOfWork, ILogger<AnnouncementsController> logger)
            : base(unitOfWork, logger)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement([FromRoute] int id)
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
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetAnnouncement));
                return BadRequest(ex.Message);
            }
            return Ok(announcement);
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>> GetAnnouncements()
        {
            IEnumerable<Announcement> announcements = null;

            try
            {
                announcements = await this._unitOfWork.AnnouncementRepository.GetAnnouncementsAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetAnnouncements));
            }

            return announcements;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public async Task<IEnumerable<Announcement>> GetAnnouncementsByUserId([FromRoute] int userId)
        {
            IEnumerable<Announcement> announcements = null;

            try
            {
                bool isUserExist = await this._unitOfWork.UserRepository.IsUserExistAsync(userId);
                if (!isUserExist)
                {
                    return null;
                }

                announcements = IsAdministrator()
                    ? await this._unitOfWork.AnnouncementRepository.GetAnnouncementsByUserIdAsync()
                    : await this._unitOfWork.AnnouncementRepository.GetAnnouncementsByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetAnnouncementsByUserId));
            }

            return announcements;
        }
    }
}