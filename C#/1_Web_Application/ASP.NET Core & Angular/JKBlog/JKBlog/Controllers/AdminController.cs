using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;
using JKBlog.Helpers.JWTs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using JKBlog.Helpers.Encryptors;
using Newtonsoft.Json;

namespace JKBlog.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly JKBlogDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminController(JKBlogDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEncryptable encryptor = new HashEncryptor();
            string encryptedPassword = encryptor.Encrypt(model.Password);

            bool userValid = this._context.Users.Any(u => u.Name == model.Name // Name, Password check
                && u.Password == encryptedPassword);

            if (!userValid)
            {
                return Unauthorized();
            }

            var jwtGenerator = new JWTGenerator(this._configuration);
            var jwt = jwtGenerator.GetToken(model);

            var response = new
            {
                auth_token = jwt
            };
            JsonConvert.SerializeObject(response, Formatting.Indented);

            return new OkObjectResult(response);
        }
    }
}