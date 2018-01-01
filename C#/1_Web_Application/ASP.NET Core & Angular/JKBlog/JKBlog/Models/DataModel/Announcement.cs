using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKBlog.Models.DataModel
{
    public class Announcement
    {
        public int AnnouncmentId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool ShowFlag { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
