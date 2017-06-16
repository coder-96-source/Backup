using MyArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArticles.Controllers
{
    public class HomeController : Controller
    {
        private const int PAGE_SIZE = 6; // 6 Topic per page
        private EFDbContext db = new EFDbContext();
        public ActionResult Index(int page = 1)
        {
            TopicVM topicVM = new TopicVM
            {
                Topics = db.Topics
                    .OrderBy(t => t.TopicId)
                    .Skip((page - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = db.Topics.Count()
                }
            };
            return View(topicVM);
        }
        public ActionResult About()
        {
            return View();
        } 
        public ActionResult Contact()
        {
            return View();
        }

        public FileContentResult GetImage(int id)
        {
            var topic = db.Topics.FirstOrDefault(m => m.TopicId == id);

            if (topic != null)
            {
                return File(topic.Picture, topic.PictureMimeType);
            }
            return null;
        }
    }
}