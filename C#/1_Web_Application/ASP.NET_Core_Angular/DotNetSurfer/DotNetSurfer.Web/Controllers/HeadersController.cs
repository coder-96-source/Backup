using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Repositories.Interfaces;
using DotNetSurfer.Web.Helpers;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class HeadersController : BaseController
    {
        public HeadersController(IUnitOfWork unitOfWork, ILogger<HeadersController> logger)
            : base(unitOfWork, logger)
        {

        }

        [HttpGet("menu/side")]
        public async Task<IEnumerable<Header>> GetSideHeaderMenus()
        {
            IEnumerable<Header> sideMenus = null;

            try
            {
                var entity = await this._unitOfWork.TopicRepository.GetSideHeaderMenusAsync();
                sideMenus = entity?.Select(h => h.MapToDomainHeader());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetSideHeaderMenus));
            }

            return sideMenus;
        }
    }
}