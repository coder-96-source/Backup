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
    public class AnnouncementsController : BaseController
    {
        public AnnouncementsController(DotNetSurferDbContext context, ILogger<AnnouncementsController> logger)
            : base(context, logger)
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

                announcement = await this._context.Announcements
                    .Include(a => a.User)
                    .Include(a => a.Status)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(a => a.AnnouncementId == id);

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
        public IEnumerable<Announcement> GetAnnouncements()
        {
            IEnumerable<Announcement> announcements = null;

            try
            {
                announcements = this._context.Announcements
                    .Include(a => a.User)
                    .Include(a => a.Status)
                    .Where(a => a.ShowFlag)
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetAnnouncements));
            }

            return announcements;
        }

        [HttpGet("users/{userId}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public IEnumerable<Announcement> GetAnnouncementsByUserId([FromRoute] int userId)
        {
            IEnumerable<Announcement> announcements = null;

            try
            {
                bool isUserExist = this._context.Users
                    .Any(u => u.UserId == userId);
                if (!isUserExist)
                {
                    return null;
                }

                announcements = IsAdministrator()
                    ? this._context.Announcements
                        .Include(a => a.User)
                        .Include(a => a.Status)
                        .AsNoTracking()
                    : this._context.Announcements
                        .Include(a => a.User)
                        .Include(a => a.Status)
                        .Where(a => a.UserId == userId)
                        .AsNoTracking();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetAnnouncementsByUserId));
            }

            return announcements;
        }
    }
}