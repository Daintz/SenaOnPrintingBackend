using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class WarehouseModel
    {
        public WarehouseModel()
        {
            // Supplies = new HashSet<SupplyModel>();
            SupplyDetails = new HashSet<SupplyDetailModel>();
        }

        public long Id { get; set; }
        public long? WarehouseTypeId { get; set; }
        public string? Ubication { get; set; }
        public bool? StatedAt { get; set; }

        public virtual WarehouseTypeModel? WarehouseType { get; set; }
        //public virtual ICollection<SupplyModel> Supplies { get; set; }
        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
    }
}
