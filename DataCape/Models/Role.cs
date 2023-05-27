using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Role
    {
        public Role()
        {
            PermissionsByRoles = new HashSet<PermissionsByRole>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<PermissionsByRole> PermissionsByRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
