using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public  class ProviderModel
    {
        public ProviderModel()
        {
            QuotationProviders = new HashSet<QuotationProviderModel>();
            BuySupplies = new List<BuySupplyModel>();
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
        [JsonIgnore]
        public virtual List<BuySupplyModel> BuySupplies { get; set; }
    }
}
