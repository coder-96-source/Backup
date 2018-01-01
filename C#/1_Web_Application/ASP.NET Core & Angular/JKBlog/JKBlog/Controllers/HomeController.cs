using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;

namespace JKBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly JKBlogDbContext _context;
        private readonly int _postCount; // number of posted articles

        public HomeController(JKBlogDbContext context)
        {
            this._context = context;
            this._postCount = 6;
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

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("GetArticles")]
        public IEnumerable<Article> GetArticles()
        {
            #region Dummy Data
            var permission = new Permission() { PermissionId = 0, PermissionType = "Admin", Users = null };
            var user = new User() { UserId = 0, Name = "JK", Permission = null, Password = "0000" };
            var tag = new Tag() { TagId = 0, ArticleId = 0, Content = "tag" };
            var articles = new Article[]
            {
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
                new Article { ArticleId = 0, TopicId = 0, Title = "Title1", Content="Content", ContentDisplay = "ContentDisplay",
                    Category = "Category",
                    PostDate = DateTime.Now, ModifyDate = DateTime.Now, ReadCount = 0, ShowFlag = true,
                    Tag = tag,
                    User = user
                },
            };
            #endregion

            return articles;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        [ActionName("GetAnnouncements")]
        public IEnumerable<Announcement> GetAnnouncements()
        {
            #region Dummy Data
            var user = new User() { UserId = 0, Name = "JK", Permission = null, Password = "0000" };
            var announcements = new Announcement[]
            {
                new Announcement { AnnouncmentId = 0, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
                new Announcement { AnnouncmentId = 1, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
                new Announcement { AnnouncmentId = 2, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
                new Announcement { AnnouncmentId = 3, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
                new Announcement { AnnouncmentId = 4, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
                new Announcement { AnnouncmentId = 5, Content = "content", PostDate = DateTime.Now, ModifyDate = DateTime.Now, ShowFlag = true, User = user },
            };
            #endregion

            return announcements;
        }
    }
}
