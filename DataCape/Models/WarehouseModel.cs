using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class WarehouseModel
    {
        public long IdWarehouse { get; set; }
        public string Name { get; set; } = null!;
        public string Ubication { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public long? IdTypeWarehouse { get; set; }

        public virtual WarehouseTypeModel? IdTypeWarehouseNavigation { get; set; }
        public virtual SupplyModel? Supply { get; set; }
    }
}
