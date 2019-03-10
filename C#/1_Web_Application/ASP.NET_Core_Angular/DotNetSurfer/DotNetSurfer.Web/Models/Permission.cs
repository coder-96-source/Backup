using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetSurfer.Web.Models
{
    public class Permission
    {
        [HiddenInput(DisplayValue = false)]
        public int PermissionId { get; set; }

        public PermissionType PermissionType { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public enum PermissionType
    {
        Admin = 0,
        User = 1
    };
}
