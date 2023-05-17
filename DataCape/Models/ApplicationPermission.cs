using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ApplicationPermission
    {
        public ApplicationPermission()
        {
            PermissionsByRoles = new HashSet<PermissionsByRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PermissionsByRole> PermissionsByRoles { get; set; }
    }
}
