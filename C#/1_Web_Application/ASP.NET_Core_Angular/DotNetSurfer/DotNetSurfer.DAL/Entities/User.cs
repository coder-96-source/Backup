using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetSurfer.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Introduction { get; set; }

        public DateTime? Birthdate { get; set; }

        public byte[] Picture { get; set; }

        public string PictureMimeType { get; set; }

        public int PermissionId { get; set; }

        public Permission Permission { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Announcement> Announcements { get; set; }
    }
}