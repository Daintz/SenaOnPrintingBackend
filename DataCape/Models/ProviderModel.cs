using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ProviderModel
    {
        public ProviderModel()
        {
            QuotationProviders = new HashSet<QuotationProviderModel>();
            SupplyDetails = new HashSet<SupplyDetailModel>();
        }

        public long IdProvider { get; set; }
        public bool? StatedAt { get; set; }
        public string NameCompany { get; set; } = null!;
        public Guid NitCompany { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;

        public virtual ICollection<QuotationProviderModel> QuotationProviders { get; set; }
        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
    }
}
