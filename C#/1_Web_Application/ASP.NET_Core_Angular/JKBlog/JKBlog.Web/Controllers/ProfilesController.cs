using System;
using System.Threading.Tasks;
using JKBlog.Helpers.ModelConverters;
using JKBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JKBlog.Controllers
{
    public class ProfilesController : BaseController
    {
        public ProfilesController(JKBlogDbContext context, ILogger<ProfilesController> logger)
            : base(context, logger)
        {

        }

        [HttpGet("{id}")]
        [Authorize(Roles = nameof(PermissionType.Admin) + "," + nameof(PermissionType.User))]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            Base64User base64User = null;

            try
            {
                var user = await this._context.Users
                    .SingleOrDefaultAsync(u => u.UserId == id);
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

                ClearSensitiveUserInformation(user);

                base64User = ModelConverter.ConvertBinaryModelsToBase64Models
                        (user, _base64UserType.Value, _targetPropertyNames.Value) as Base64User;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetUser));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(base64User);
        }
    }
}