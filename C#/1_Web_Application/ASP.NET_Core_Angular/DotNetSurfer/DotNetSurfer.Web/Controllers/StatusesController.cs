using System;
using System.Collections.Generic;
using System.Linq;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class StatusesController : BaseController
    {
        public StatusesController(DotNetSurferDbContext context, ILogger<StatusesController> logger)
            : base(context, logger)
        {

        }

        [HttpGet]
        public IEnumerable<Status> Statuses()
        {
            IEnumerable<Status> statuses = null;

            try
            {
                statuses = this._context.Statuses.ToList();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(Statuses));
            }

            return statuses;
        }
    }
}