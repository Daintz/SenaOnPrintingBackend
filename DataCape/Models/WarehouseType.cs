using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class WarehouseType
    {
        public long IdTypeWarehouse { get; set; }
        public bool? StatedAt { get; set; }
        public string? Nametype { get; set; }
        public string? Description { get; set; }

        public virtual Warehouse? Warehouse { get; set; }
    }
}
