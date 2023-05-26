using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class PermissionsByRoleModel
    {
        public long Id { get; set; }
        public long? PermissionId { get; set; }
        public long? RoleId { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ApplicationPermissionModel? Permission { get; set; }
        public virtual RoleModel? Role { get; set; }
    }
}
