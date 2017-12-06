using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    [Table("Article")]
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }
        [Display(Name = "Topic")]
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        //[AllowHtml]
        public string Content { get; set; }
        //[AllowHtml]
        public string ContentDisplay { get; set; }
        public string Category { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate { get; set; }
        [Display(Name = "Show")]
        public bool ShowFlag { get; set; }
        public IEnumerable<Tag> Tags
        {
            get { return new EFDbContext().Tags.Where(t => t.ArticleId == ArticleId); }
        }
    }
}