using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Product
    {
        public Product()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long IdProduct { get; set; }
        public bool? StatedAt { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Characteristics { get; set; } = null!;
        public long IdSupply { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
