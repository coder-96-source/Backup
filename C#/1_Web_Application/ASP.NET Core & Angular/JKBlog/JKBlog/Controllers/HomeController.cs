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
    //[Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly JKBlogDbContext _context;

        public HomeController(JKBlogDbContext context)
        {
            this._context = context;
        }

        //[Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("[controller]/[action]")]
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/[action]/{id}")]
        public async Task<IActionResult> Article([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await this._context.Articles.SingleOrDefaultAsync(t => t.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            //var base64Article = ModelConverter.ConvertBinaryModelsToBase64Models
            //    (article, _base64ArticleType.Value, _targetPropertyNames.Value) as Base64Article;

            //return Ok(base64Article);
            return Ok(article);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public IEnumerable<Article> Articles()
        {
            var articles = this._context.Articles
                .Include(article => article.User)
                .Include(article => article.Topic)
                .ToList();

            return articles;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public IEnumerable<Announcement> Announcements()
        {
            var announcements = this._context.Announcements
                .Include(announcement => announcement.User)
                .ToList();

            return announcements;
        }
    }
}
