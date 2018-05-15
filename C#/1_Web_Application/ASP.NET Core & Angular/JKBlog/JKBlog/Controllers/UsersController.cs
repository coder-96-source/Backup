using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JKBlog.Models.DataModel;
using JKBlog.Helpers.Encryptors;
using JKBlog.Helpers.JWTs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JKBlog.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private enum Permission { Admin, User };
        private readonly JKBlogDbContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(JKBlogDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [HttpPost]
        [ActionName("SignUp")]
        public async Task<IActionResult> CreateUser([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (this._context.Users.Any(u => u.Name == model.Name))
            {
                return BadRequest("User name already exists");
            }

            IEncryptable encryptor = new HashEncryptor();
            string encryptedPassword = encryptor.Encrypt(model.Password);
            var user = new User()
            {
                Name = model.Name,
                Password = encryptedPassword,
                Birthdate = model.Birthdate,
                Picture = model.Picture,
                PictureMimeType = model.PictureMimeType,
                PermissionId = (int)Permission.User // default
            };

            this._context.Users.Add(user);
            await this._context.SaveChangesAsync();

            return new OkObjectResult("User created");
        }

        [HttpPost]
        [ActionName("SignIn")]
        public IActionResult SignIn([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Existence check
            bool isUserExist = this._context.Users.Any(u => u.Name == model.Name);
            if (!isUserExist)
            {
                return NotFound();
            }

            // Password check
            IEncryptable encryptor = new HashEncryptor();
            string encryptedPassword = encryptor.Encrypt(model.Password);
            bool isPasswordCorrect = this._context.Users.FirstOrDefault(u => u.Name == model.Name)
                .Password == encryptedPassword ? true : false;
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }

            var jwtGenerator = new JWTGenerator(this._configuration);
            var jwt = jwtGenerator.GetToken(model);
            var user = this._context.Users.FirstOrDefault(u => u.Name == model.Name);
            user.Password = null; // clear password to be secure
            var response = new
            {
                auth_token = jwt,
                user = user
            };
            JsonConvert.SerializeObject(response, Formatting.Indented);

            return new OkObjectResult(response);
        }
    }
}