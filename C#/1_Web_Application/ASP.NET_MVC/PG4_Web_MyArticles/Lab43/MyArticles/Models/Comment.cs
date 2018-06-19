using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyArticles.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CommentPassword { get; set; }
        public DateTime PostTime { get; set; }
    }
}