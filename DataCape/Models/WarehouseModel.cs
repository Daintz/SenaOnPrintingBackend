using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class WarehouseModel
    {
        public WarehouseModel()
        {
            //Supplies = new HashSet<SupplyModel>();
            SupplyDetails = new HashSet<SupplyDetailModel>();
            BuySuppliesDetails = new List<BuySuppliesDetailModel>();
        }

        public long Id { get; set; }
        public long TypeServiceId { get; set; }
        public string? Ubication { get; set; }
        public bool? StatedAt { get; set; }

        public virtual TypeServiceModel TypeServices { get; set; }
        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
        [JsonIgnore]
        public virtual List<BuySuppliesDetailModel> BuySuppliesDetails { get; set; }
    }
}