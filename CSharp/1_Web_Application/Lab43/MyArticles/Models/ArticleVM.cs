using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArticles.Models
{
    public class ArticleVM
    {
        public IEnumerable<Article> Articles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public SelectList SelectList { get; set; }
        public string CurrentTopic { get; set; }
    }
}