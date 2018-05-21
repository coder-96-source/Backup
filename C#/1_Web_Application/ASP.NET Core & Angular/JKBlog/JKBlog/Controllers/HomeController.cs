using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace JKBlog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        //[HttpGet("{id}")]
        //[Route("api/[controller]/[action]/{id}")]
        //public async Task<IActionResult> Article([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var article = await this._context.Articles
        //        .Include(a => a.User)
        //        .Include(a => a.Topic)
        //        .SingleOrDefaultAsync(a => a.ArticleId == id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    var base64Article = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (article, _base64ArticleType.Value, _targetPropertyNames.Value) as Base64Article;

        //    // Clear sensitive user information
        //    ClearSensitiveUserInformation(base64Article.User);

        //    return Ok(base64Article);
        //}

        //[HttpGet]
        //[Route("api/[controller]/[action]")]
        //public IEnumerable<Base64Article> Articles()
        //{
        //    var articles = this._context.Articles
        //        .Include(article => article.User)
        //        .Include(article => article.Topic)
        //        .ToArray();

        //    var base64Articles = ModelConverter.ConvertBinaryModelsToBase64Models
        //        (articles, _base64ArticleType.Value, _targetPropertyNames.Value) as IEnumerable<Base64Article>;

        //    // Clear sensitive user information
        //    foreach (var article in base64Articles)
        //    {
        //        ClearSensitiveUserInformation(article.User);
        //    }

        //    return base64Articles;
        //}

        //[HttpGet]
        //[Route("api/[controller]/[action]")]
        //public IEnumerable<Announcement> Announcements()
        //{
        //    var announcements = this._context.Announcements
        //        .Include(announcement => announcement.User)
        //        .ToList();

        //    // Clear sensitive user information
        //    foreach (var announcement in announcements)
        //    {
        //        ClearSensitiveUserInformation(announcement.User);
        //    }

        //    return announcements;
        //}
    }
}
