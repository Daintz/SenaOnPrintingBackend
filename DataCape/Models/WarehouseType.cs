using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class WarehouseType
    {
        public WarehouseType()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
