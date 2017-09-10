using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArticles.Models
{
    [Table("Keyword")]
    public class Keyword
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int KeywordId { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
    }
}