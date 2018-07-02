using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JKBlog.Models
{
    public class Permission
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int PermissionId { get; set; }

        public string PermissionType { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public enum PermissionType
    {
        Admin = 0,
        User = 1
    };
}
