using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class WarehouseTypeModel
    {
        public WarehouseTypeModel()
        {
            Warehouse = new HashSet<WarehouseModel>();
        }
        public long IdTypeWarehouse { get; set; }
        public bool? StatedAt { get; set; }
        public string? Nametype { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<WarehouseModel> Warehouse { get; set; }
    }
}
