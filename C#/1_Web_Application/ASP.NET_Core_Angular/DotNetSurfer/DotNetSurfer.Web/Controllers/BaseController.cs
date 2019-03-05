using System;
using System.Linq;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseController> _logger;

        public BaseController(IUnitOfWork unitOfWork, ILogger<BaseController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
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