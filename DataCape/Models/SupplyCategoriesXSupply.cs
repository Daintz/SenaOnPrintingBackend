using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyCategoriesXSupply
    {
        public long IdSupply { get; set; }
        public long IdSupplyCategory { get; set; }

        public virtual SupplyCategory IdSupplyCategoryNavigation { get; set; } = null!;
        public virtual Supply IdSupplyNavigation { get; set; } = null!;
    }
}
