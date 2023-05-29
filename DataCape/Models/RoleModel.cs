using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class RoleModel
    {
        public RoleModel()
        {
            PermissionsByRoles = new HashSet<PermissionsByRoleModel>();
            Users = new HashSet<UserModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<PermissionsByRoleModel> PermissionsByRoles { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
