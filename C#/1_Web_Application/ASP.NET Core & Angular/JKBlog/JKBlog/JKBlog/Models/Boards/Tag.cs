using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int TagId { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
    }
}