using System;
using System.Collections.Generic;

namespace DataCape
{
    public  class SupplyDetailModel
    {
        public long Id { get; set; }
        public long? SupplyId { get; set; }
        public long? ProviderId { get; set; }
        public string? Description { get; set; }
        public decimal? SupplyCost { get; set; }
        public string? Batch { get; set; }
        public int InitialQuantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? ActualQuantity { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ProviderModel? Provider { get; set; }
        public virtual SupplyModel? Supply { get; set; }
    }
}
