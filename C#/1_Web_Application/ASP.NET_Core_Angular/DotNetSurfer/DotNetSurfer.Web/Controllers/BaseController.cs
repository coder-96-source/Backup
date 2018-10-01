using System;
using System.Collections.Generic;
using System.Linq;
using DotNetSurfer.Web.Helpers.Encryptors;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected static readonly Lazy<HashEncryptor> _encryptor = new Lazy<HashEncryptor>(() => new HashEncryptor());
        protected static readonly Lazy<Type> _binaryTopicType = new Lazy<Type>(() => typeof(Topic));
        protected static readonly Lazy<Type> _binaryArticleType = new Lazy<Type>(() => typeof(Article));
        protected static readonly Lazy<Type> _binaryUserType = new Lazy<Type>(() => typeof(User));
        protected static readonly Lazy<List<string>> _targetPropertyNames = new Lazy<List<string>>(() => {
            return new List<string>() { "Picture" };
        }); // binary, base64 property names

        protected readonly DotNetSurferDbContext _context;
        protected readonly ILogger<BaseController> _logger;

        public BaseController(DotNetSurferDbContext context, ILogger<BaseController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        protected bool IsTopicExists(int id)
        {
            return this._context.Topics.Any(t => t.TopicId == id);
        }

        protected bool IsArticleExists(int id)
        {
            return this._context.Articles.Any(t => t.ArticleId == id);
        }

        protected bool IsAnnouncementExists(int id)
        {
            return this._context.Announcements.Any(a => a.AnnouncementId == id);
        }

        protected bool IsUserExists(int id)
        {
            return this._context.Users.Any(u => u.UserId == id);
        }

        protected bool IsUserEmailExists(string email)
        {
            return this._context.Users.Any(u => u.Email == email);
        }

        protected bool IsPasswordCorrect(string storedPassword, string inputPassword)
        {
            string encryptedPassword = _encryptor.Value.Encrypt(inputPassword);
            return storedPassword == encryptedPassword ? true : false;
        }

        protected bool IsAdministrator()
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            return roleClaim?.Value == nameof(PermissionType.Admin) ? true : false; 
        }

        protected int? GetUserIdFromClaims()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int? userId = string.IsNullOrEmpty(userIdClaim?.Value) ? (int?)null : Convert.ToInt32(userIdClaim.Value);
            return userId;
        }
    }
}