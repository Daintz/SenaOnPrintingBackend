using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PermissionsXRoleModel
    {
        public Guid IdPermission { get; set; }
        public Guid IdRole { get; set; }

        public virtual PermissionModel IdPermissionNavigation { get; set; } = null!;
        public virtual RoleModel IdRoleNavigation { get; set; } = null!;
    }
}
