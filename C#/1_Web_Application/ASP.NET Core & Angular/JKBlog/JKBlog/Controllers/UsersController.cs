using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JKBlog.Models.DataModel;
using JKBlog.Helpers.Encryptors;

namespace JKBlog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private enum Permission { Admin, User };
        private readonly JKBlogDbContext _context;
    
        public UsersController(JKBlogDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User model)
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
    }
}