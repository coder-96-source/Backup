using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JKBlog.Models.Users
{
    [Table("Permission")]
    public class Permission
    {
        public int UserId { get; set; }
        [Required]
        public string PermissionType { get; set; }
    }
}
