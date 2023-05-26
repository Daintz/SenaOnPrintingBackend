using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class SupplyCategoriesXSupply
    {
        public long? SupplyId { get; set; }
        public long? SupplyCategory { get; set; }

        public virtual SupplyModel? Supply { get; set; }
        public virtual SupplyCategory? SupplyCategoryNavigation { get; set; }
    }
}
