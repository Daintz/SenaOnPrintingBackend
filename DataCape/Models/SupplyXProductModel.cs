using System;
using System.Collections.Generic;

namespace DataCape
{
    public class SupplyXProductModel
    {
        public long? ProductId { get; set; }
        public long? SupplyId { get; set; }

        public virtual ProductModel? Product { get; set; }
        public virtual SupplyModel? Supply { get; set; }
    }
}
