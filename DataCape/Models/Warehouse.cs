using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Supplies = new HashSet<Supply>();
        }

        public long Id { get; set; }
        public long? WarehouseTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Ubication { get; set; }
        public bool? StatedAt { get; set; }

        public virtual WarehouseType? WarehouseType { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
