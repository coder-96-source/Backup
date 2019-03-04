using System;
using DotNetSurfer.DAL.Repositories.Interfaces;
using DotNetSurfer.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Web.Controllers
{
    public class LogsController : BaseController
    {
        public LogsController(IUnitOfWork unitOfWork, ILogger<LogsController> logger)
            : base(unitOfWork, logger)
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