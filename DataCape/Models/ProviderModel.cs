using System;
using System.Collections.Generic;

namespace DataCape
{
    public  class ProviderModel
    {
        public ProviderModel()
        {
            QuotationProviders = new HashSet<QuotationProviderModel>();
            SupplyDetails = new HashSet<SupplyDetailModel>();
        }

        public long Id { get; set; }
        public string NameCompany { get; set; } = null!;
        public string NitCompany { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? CompanyAddress { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationProviderModel> QuotationProviders { get; set; }
        public virtual ICollection<SupplyDetailModel> SupplyDetails { get; set; }
    }
}
