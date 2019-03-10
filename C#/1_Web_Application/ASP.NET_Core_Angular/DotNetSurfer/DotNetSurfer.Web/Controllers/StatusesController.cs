using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSurfer.Web.Models;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using DotNetSurfer.Web.Helpers;

namespace DotNetSurfer.Web.Controllers
{
    public class StatusesController : BaseController
    {
        public StatusesController(IUnitOfWork unitOfWork, ILogger<StatusesController> logger)
            : base(unitOfWork, logger)
        {

        }

        [HttpGet]
        public async Task<IEnumerable<Status>> Statuses()
        {
            IEnumerable<Status> statuses = null;

            try
            {
                var entityModels = await this._unitOfWork.StatusRepository
                    .GetStatusesAsync();

                statuses = entityModels?.Select(s => s.MapToDomain());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(Statuses));
            }

            return statuses;
        }
    }
}