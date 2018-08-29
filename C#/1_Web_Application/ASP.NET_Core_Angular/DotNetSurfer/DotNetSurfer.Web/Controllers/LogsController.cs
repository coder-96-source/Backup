using System;
using DotNetSurfer.Web.Controllers;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Web.Controllers
{
    public class LogsController : BaseController
    {
        public LogsController(DotNetSurferDbContext context, ILogger<LogsController> logger)
            : base(context, logger)
        {

        }

        [HttpPost("error")]
        public void WriteErrorLog(string message)
        {
            try
            {
                this._logger.LogError(message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(WriteErrorLog));
            }
        }

        [HttpPost("info")]
        public void WriteInfoLog(string message)
        {
            try
            {
                this._logger.LogInformation(message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(WriteInfoLog));
            }
        }
    }
}