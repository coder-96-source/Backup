using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JKBlog.Controllers;
using JKBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JKBlog.Web.Controllers
{
    public class LogsController : BaseController
    {
        public LogsController(JKBlogDbContext context, ILogger<LogsController> logger)
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