using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool ShowFlag { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}