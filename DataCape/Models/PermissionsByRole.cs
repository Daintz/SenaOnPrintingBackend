using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class PermissionsByRole
    {
        public long Id { get; set; }
        public long? PermissionId { get; set; }
        public long? RoleId { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ApplicationPermission? Permission { get; set; }
        public virtual Role? Role { get; set; }
    }
}
