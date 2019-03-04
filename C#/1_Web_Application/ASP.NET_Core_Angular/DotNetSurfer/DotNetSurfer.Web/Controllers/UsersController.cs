using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetSurfer.Web.Helpers.JWTs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DotNetSurfer.DAL.Repositories.Interfaces;
using DotNetSurfer.DAL.Entities;

namespace DotNetSurfer.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : BaseController
    {
        private readonly IConfiguration _configuration;

        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<UsersController> logger) 
            : base(unitOfWork, logger)
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

                bool isUserEmailExist = await this._unitOfWork.UserRepository.IsEmailExistAsync(model.Email);
                if (isUserEmailExist)
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

                this._unitOfWork.UserRepository.Create(user);
                await this._unitOfWork.UserRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(SignUp));
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] User model)
        {
            object response = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await this._unitOfWork.UserRepository.GetUserByEmailAsync(model.Email);
                if (user == null)
                {
                    return NotFound("Please check that your email addresses");
                }

                if (!IsPasswordCorrect(user.Password, model.Password))
                {
                    return BadRequest("Wrong type of the password, please enter it again");
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