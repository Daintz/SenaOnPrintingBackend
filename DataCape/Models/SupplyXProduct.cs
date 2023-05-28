using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyXProduct
    {
        public long IdSupply { get; set; }
        public long IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Supply IdSupplyNavigation { get; set; } = null!;
    }
}
