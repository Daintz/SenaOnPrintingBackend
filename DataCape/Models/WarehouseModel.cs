using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class WarehouseModel
    {
        public WarehouseModel()
        {
            // Supplies = new HashSet<SupplyModel>();
            SupplyDetails = new List<SupplyDetailModel>();
        }

        public long Id { get; set; }
        public long? TypeServiceId { get; set; }
        public string? Ubication { get; set; }
        public bool? StatedAt { get; set; }

        public virtual TypeServiceModel? TypeServices { get; set; }
        public virtual List<SupplyModel> Supplies { get; set; }
        public virtual List<SupplyDetailModel> SupplyDetails { get; set; }
    }
}