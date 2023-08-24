using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class RoleModel
    {
        public RoleModel()
        {
            PermissionsByRoles = new List<PermissionsByRoleModel>();
            Users = new List<UserModel>();
            //Permissions = new List<ApplicationPermissionModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        [JsonIgnore]
        public virtual List<PermissionsByRoleModel> PermissionsByRoles { get; set; }

        [JsonIgnore]
        public virtual List<ApplicationPermissionModel> Permissions { get; set; }
        public virtual List<UserModel> Users { get; set; }
    }
}
