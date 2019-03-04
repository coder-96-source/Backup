using System;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Repositories.Interfaces;
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
        public async Task<object> GetSideHeaderMenus()
        {
            object sideMenus = null;

            try
            {
                sideMenus = await this._unitOfWork.TopicRepository.GetSideHeaderMenusAsync();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetSideHeaderMenus));
            }

            return sideMenus;
        }
    }
}