using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.Web.Models
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
