using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class SupplyXProduct
    {
        public long? ProductId { get; set; }
        public long? SupplyId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Supply? Supply { get; set; }
    }
}
