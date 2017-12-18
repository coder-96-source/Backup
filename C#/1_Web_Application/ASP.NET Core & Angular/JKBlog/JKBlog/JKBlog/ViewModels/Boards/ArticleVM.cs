using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    // 수정예정
    public class ArticleVM
    {
        public IEnumerable<Article> Articles { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
        // legacy
        //public IEnumerable<Article> Articles { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        //public SelectList SelectList { get; set; }
        //public string CurrentTopic { get; set; }
    }
}