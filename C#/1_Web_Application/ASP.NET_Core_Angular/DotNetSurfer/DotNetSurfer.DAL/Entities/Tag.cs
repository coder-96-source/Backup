using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetSurfer.DAL.Entities
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int TagId { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}