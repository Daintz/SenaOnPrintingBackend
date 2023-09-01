using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class TypeServiceModel
    {
        public TypeServiceModel()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetailModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientDetailModel> QuotationClientDetails { get; set; }
    }
}