using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetSurfer.Web.Models;
using DotNetSurfer.Web.Helpers.JWTs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : BaseController
    {
        private readonly IConfiguration _configuration;

        public UsersController(DotNetSurferDbContext context, IConfiguration configuration, ILogger<UsersController> logger) 
            : base(context, logger)
        {
            this._configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (IsUserEmailExists(model.Email))
                {
                    return BadRequest("User email already exists");
                }

                string encryptedPassword = _encryptor.Value.Encrypt(model.Password);
                var user = new User()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = encryptedPassword,
                    Birthdate = model.Birthdate,
                    Picture = model.Picture,
                    PictureMimeType = model.PictureMimeType,
                    PermissionId = (int)PermissionType.User // default
                };

                this._context.Users.Add(user);
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(SignUp));
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult SignIn([FromBody] User model)
        {
            object response = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!IsUserEmailExists(model.Email))
                {
                    return NotFound();
                }

                var user = this._context.Users
                    .Include(u => u.Permission)
                    .First(u => u.Email == model.Email);
                if (!IsPasswordCorrect(user.Password, model.Password))
                {
                    return Unauthorized();
                }

                var jwtGenerator = new JWTGenerator(this._configuration);
                var jwt = jwtGenerator.GetToken(user);
                HttpContext.Session.SetString("_UserEmail", user.Email); // Set user info to session for logging
                user.Password = null; // Clear password to be secure
                response = new
                {
                    auth_token = jwt,
                    user = user
                };
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(SignIn));
            }

            return new OkObjectResult(response);
        }
    }
}