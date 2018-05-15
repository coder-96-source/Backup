using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JKBlog.Models.DataModel;

namespace JKBlog.Controllers
{
    public abstract class BaseController : Controller
    {
        protected static readonly Lazy<Type> _binaryTopicType = new Lazy<Type>(() => typeof(Topic));
        protected static readonly Lazy<Type> _binaryArticleType = new Lazy<Type>(() => typeof(Article));
        protected static readonly Lazy<Type> _base64TopicType = new Lazy<Type>(() => typeof(Base64Topic));
        protected static readonly Lazy<Type> _base64ArticleType = new Lazy<Type>(() => typeof(Base64Article));
        protected static readonly Lazy<List<string>> _targetPropertyNames = new Lazy<List<string>>(() => {
            return new List<string>() { "Picture" };
        }); // binary, base64 property names

        protected readonly JKBlogDbContext _context;

        public BaseController(JKBlogDbContext context)
        {
            this._context = context;
        }
    }
}
