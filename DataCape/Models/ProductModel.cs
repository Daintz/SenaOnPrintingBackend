using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public   class ProductModel
    {
        public ProductModel()
        {
            QuotationClientDetails = new List<QuotationClientDetailModel>();
        }

        public long Id { get; set; }
        public string TypeProduct { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
        public decimal? Cost { get; set; }

        public virtual List<QuotationClientDetailModel> QuotationClientDetails { get; set; }
    }
}
