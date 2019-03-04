using System;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class ProfilesController : BaseController
    {
        public ProfilesController(IUnitOfWork unitOfWork, ILogger<ProfilesController> logger)
            : base(unitOfWork, logger)
        {

        }

        [HttpGet("{id}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            User user = null;

            try
            {
                user = await this._unitOfWork.UserRepository.GetUserAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                // Author check
                int? userId = GetUserIdFromClaims();
                if (!IsAdministrator() && id != userId.Value)
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetUser));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }
    }
}