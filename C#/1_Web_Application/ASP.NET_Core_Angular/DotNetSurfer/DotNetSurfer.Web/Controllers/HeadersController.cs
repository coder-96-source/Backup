using System;
using System.Collections.Generic;
using System.Linq;
using DotNetSurfer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web.Controllers
{
    public class HeadersController : BaseController
    {
        public HeadersController(DotNetSurferDbContext context, ILogger<HeadersController> logger)
            : base(context, logger)
        {

        }

        [HttpGet("menu/side")]
        public object GetSideHeaderMenus()
        {
            object sideMenus = null;

            try
            {
                sideMenus = this._context.Topics
                    .Where(t => t.ShowFlag)
                    .Select(t => new {
                        Id = t.TopicId,
                        Title = t.Title,
                        SideNodes = t.Articles
                        .Where(a => a.ShowFlag)
                        .Select(a => new {
                            Id = a.ArticleId,
                            Title = a.Title
                        })
                    });

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, nameof(GetSideHeaderMenus));
            }

            return sideMenus;
        }
    }
}