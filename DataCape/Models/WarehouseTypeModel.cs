using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class WarehouseTypeModel
    {
        public WarehouseTypeModel()
        {
            Warehouses = new HashSet<WarehouseModelModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<WarehouseModelModel> Warehouses { get; set; }
    }
}
