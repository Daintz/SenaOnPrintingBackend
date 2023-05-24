using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PermissionsXRole
    {
        public long IdPermission { get; set; }
        public long IdRole { get; set; }

        public virtual Permission IdPermissionNavigation { get; set; } = null!;
        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}
