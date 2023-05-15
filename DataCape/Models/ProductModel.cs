using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long IdProduct { get; set; }
        public bool? StatedAt { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Characteristics { get; set; } = null!;
        public long IdSupply { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
