using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Content { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}