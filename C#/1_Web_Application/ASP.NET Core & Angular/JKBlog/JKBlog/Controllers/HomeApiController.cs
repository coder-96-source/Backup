using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using JKBlog.Helpers.ModelConverters;

namespace JKBlog.Controllers
{
    [Route("api/Home/[action]")]
    public class HomeApiController : BaseApiController
    {
        public HomeApiController(JKBlogDbContext context) : base(context)
        {

        }        
    }
}
