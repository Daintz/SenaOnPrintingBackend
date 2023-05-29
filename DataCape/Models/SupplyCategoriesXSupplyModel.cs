using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyCategoriesXSupplyModel
    {
        public long? SupplyId { get; set; }
        public long? SupplyCategory { get; set; }

        public virtual SupplyModel? Supply { get; set; }
        public virtual SupplyCategoryModel? SupplyCategoryNavigation { get; set; }
    }
}
