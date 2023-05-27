using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Product
    {
        public Product()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetail>();
        }

        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientDetail> QuotationClientDetails { get; set; }
    }
}
