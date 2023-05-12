using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class WarehouseModel
    {
        public Guid IdWarehouse { get; set; }
        public string Name { get; set; } = null!;
        public string TypeWarehouse { get; set; } = null!;
        public string Ubication { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual SupplyModel? Supply { get; set; }
    }
}
