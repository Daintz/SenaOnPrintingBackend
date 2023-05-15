using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PermissionsXRoleModel
    {
        public long IdPermission { get; set; }
        public long IdRole { get; set; }

        public virtual PermissionModel IdPermissionNavigation { get; set; } = null!;
        public virtual RoleModel IdRoleNavigation { get; set; } = null!;
    }
}
