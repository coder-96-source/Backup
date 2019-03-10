using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetSurfer.DAL.Entities
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        public string PermissionType { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
