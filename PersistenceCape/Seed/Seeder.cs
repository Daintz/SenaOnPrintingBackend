using DataCape.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Seed
{
    public class Seeder
    {
        private readonly SENAONPRINTINGContext _context;

        public Seeder(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public void Seed() { 
            if(!_context.ApplicationPermissions.Any())
            {
                var permissions = new List<ApplicationPermissionModel>()
                {
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "Role"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "Role"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "Role"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "Role"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "TypeDocument"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "TypeDocument"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "TypeDocument"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "TypeDocument"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "User"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "User"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "User"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "User"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "Warehouse"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "Warehouse"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "Warehouse"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "Warehouse"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "UnitMeasure"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "UnitMeasure"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "UnitMeasure"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "UnitMeasure"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "Pictogram"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "Pictogram"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "Pictogram"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "Pictogram"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Create",
                        Module = "SupplyCategory"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Read",
                        Module = "SupplyCategory"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Update",
                        Module = "SupplyCategory"
                    },
                    new ApplicationPermissionModel()
                    {
                        Name = "Delete",
                        Module = "SupplyCategory"
                    }
                };
                _context.ApplicationPermissions.AddRange(permissions);
                _context.SaveChanges();
            }
        }
    }
}
