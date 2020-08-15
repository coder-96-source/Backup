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
    [Table("Topic")]
    public class Topic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int TopicId { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
        public IEnumerable<Article> Articles
        {
            get { return new EFDbContext().Articles.Where(a => a.TopicId == TopicId); }
        }
    }
}