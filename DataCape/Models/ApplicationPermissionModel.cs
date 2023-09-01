using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class ApplicationPermissionModel
    {
        public ApplicationPermissionModel()
        {
            PermissionsByRoles = new List<PermissionsByRoleModel>();
            Roles = new List<RoleModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        //public string Module { get; set; } = null!;
        [JsonIgnore]
        public virtual List<PermissionsByRoleModel> PermissionsByRoles { get; set; }
        [JsonIgnore]
        public virtual List<RoleModel> Roles { get; set; }
    }
}
