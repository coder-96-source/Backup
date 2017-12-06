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
    [Table("Topic")]
    public class Topic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int TopicId { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate { get; set; }
        [Display(Name = "Show")]
        public bool ShowFlag { get; set; }
        public IEnumerable<Article> Articles
        {
            get { return new EFDbContext().Articles.Where(a => a.TopicId == TopicId); }
        }
    }
}