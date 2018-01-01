using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JKBlog.Models.DataModel
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}