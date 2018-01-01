using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentDisplay { get; set; }
        public string Category { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ReadCount { get; set; }
        public bool ShowFlag { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}