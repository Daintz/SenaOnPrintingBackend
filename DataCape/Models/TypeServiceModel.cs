using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class TypeServiceModel
    {
        public TypeServiceModel()
        {
            QuotationClientDetails = new HashSet<QuotationClientDetailModel>();
            Warehouses= new HashSet<WarehouseModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientDetailModel> QuotationClientDetails { get; set; }
        public virtual ICollection<WarehouseModel> Warehouses { get; set;}
    }
}