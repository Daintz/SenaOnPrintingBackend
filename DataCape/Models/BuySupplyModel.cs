using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class BuySupplyModel
    {
        public BuySupplyModel()
        {
            BuySuppliesDetails = new List<BuySuppliesDetailModel>();
        }

        public long Id { get; set; }
        public string? Description { get; set; }
        public long? ProviderId { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ProviderModel? Provider { get; set; }
        public virtual List<BuySuppliesDetailModel> BuySuppliesDetails { get; set; }
    }
}
