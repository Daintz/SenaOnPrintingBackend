using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Views
{
    public class RoleView
    {
        public long Id;
        public string Name;
        public string Description;
        public List<PermissionsByRoleModel> Permissions;
        public bool? StatedAt;

        //public RoleView(long Id, string Name, string Description, List<PermissionsByRoleModel> Permissions, bool StatedAt) {
        //    id = Id;
        //    name = Name;
        //    description = Description;
        //    permissions = Permissions;
        //    stated_at = StatedAt;
        //}

    }
}