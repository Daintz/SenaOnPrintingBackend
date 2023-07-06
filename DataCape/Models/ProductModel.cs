using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public   class ProductModel
    {
        public ProductModel()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetailModel>();
        }

        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Characteristics { get; set; }
        public bool? StatedAt { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<QuotationClientDetailModel> QuotationClientDetails { get; set; }
    }
}
