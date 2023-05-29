using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class ApplicationPermissionModel
    {
        public ApplicationPermissionModel()
        {
            PermissionsByRoles = new HashSet<PermissionsByRoleModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PermissionsByRoleModel> PermissionsByRoles { get; set; }
    }
}
