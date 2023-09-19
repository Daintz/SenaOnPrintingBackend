using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class UnitMeasureModel
    {
        public UnitMeasureModel()
        {
            InverseBase = new HashSet<UnitMeasureModel>();
            UnitMeasuresXSupply = new List<UnitMeasuresXSupplyModel>();
            BuySuppliesDetails = new List<BuySuppliesDetailModel>();
            //Supplies = new HashSet<SupplyModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public int Type { get; set; }
        public long? BaseId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public bool? StatedAt { get; set; }
        [JsonIgnore]
        public virtual List<UnitMeasuresXSupplyModel> UnitMeasuresXSupply { get; set; }

        public virtual UnitMeasureModel? Base { get; set; }
        public virtual ICollection<UnitMeasureModel> InverseBase { get; set; }
        //public virtual ICollection<SupplyModel> Supplies { get; set; }
        [JsonIgnore]
        public virtual List<BuySuppliesDetailModel> BuySuppliesDetails { get; set; }
    }
}
