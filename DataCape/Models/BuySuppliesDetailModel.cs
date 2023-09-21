using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class BuySuppliesDetailModel
    {

        public long Id { get; set; }
        public long? BuySuppliesId { get; set; }
        public long? SupplyId { get; set; }
        public decimal? SupplyCost { get; set; }
        public int? SupplyQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public long? WarehouseId { get; set; }
        public string? SecurityFile { get; set; }
        public bool? StatedAt { get; set; }
        public long? UnitMeasuresId { get; set; }
        [JsonIgnore]
        public virtual BuySupplyModel BuySupplies { get; set; }
        public virtual SupplyModel Supply { get; set; }
        public virtual UnitMeasureModel UnitMeasures { get; set; }
        public virtual WarehouseModel Warehouse { get; set; }

    }
}
