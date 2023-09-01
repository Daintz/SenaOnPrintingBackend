using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public   class PermissionsByRoleModel
    {
        
        public long? PermissionId { get; set; }
        public long? RoleId { get; set; }
     

        public virtual ApplicationPermissionModel? Permission { get; set; }
        public virtual RoleModel? Role { get; set; }
    }
}
