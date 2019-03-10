using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.Web.Models
{
    public class Article
    {
        [HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(10, ErrorMessage = "Category cannot be longer than 10 characters.")]
        public string Category { get; set; } = "Free";

        public byte[] Picture { get; set; }

        public string PictureMimeType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate { get; set; }

        public int ReadCount { get; set; }

        [Required]
        public bool ShowFlag { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}