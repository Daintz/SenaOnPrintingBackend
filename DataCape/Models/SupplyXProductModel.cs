using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyXProductModel
    {
        public long IdSupply { get; set; }
        public long IdProduct { get; set; }

        public virtual ProductModel IdProductNavigation { get; set; } = null!;
        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
    }
}
