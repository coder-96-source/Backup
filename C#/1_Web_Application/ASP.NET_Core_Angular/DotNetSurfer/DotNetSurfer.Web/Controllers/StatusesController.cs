using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
                statuses = await this._unitOfWork.StatusRepository.GetStatusesAsync(); ;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(Statuses));
            }

            return statuses;
        }
    }
}