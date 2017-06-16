using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArticles.Models
{
    [Table("Article")]
    public class Article
    {
        [Display(Name = "Show")]
        public bool ShowFlag { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }
        [Display(Name = "Topic")]
        public int TopicId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public IEnumerable<Keyword> Keywords
        {
            get { return new EFDbContext().Keywords.Where(k => k.ArticleId == ArticleId); }
        }
        public IEnumerable<Comment> Comments
        {
            get { return new EFDbContext().Comments.Where(c => c.ArticleId == ArticleId); }
        }
    }
}