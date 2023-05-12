using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyCategoriesXSupplyModel
    {
        public Guid IdSupply { get; set; }
        public Guid IdSupplyCategory { get; set; }

        public virtual SupplyCategoryModel IdSupplyCategoryNavigation { get; set; } = null!;
        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
    }
}
