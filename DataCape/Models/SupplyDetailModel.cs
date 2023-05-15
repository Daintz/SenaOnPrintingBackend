using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyDetailModel
    {
        public long IdSupplyDetails { get; set; }
        public long IdProvider { get; set; }
        public long IdSupply { get; set; }
        public bool? StatedAt { get; set; }
        public decimal SupplyCost { get; set; }
        public string? Batch { get; set; }
        public int InitialQuantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ActualQuantity { get; set; }

        public virtual ProviderModel IdProviderNavigation { get; set; } = null!;
        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
    }
}
