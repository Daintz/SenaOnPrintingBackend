using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyCategoryModel
    {
        public SupplyCategoryModel()
        {
            SupplyCategoriesXSupply = new List<SupplyCategoriesXSupplyModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }
        public virtual List<SupplyCategoriesXSupplyModel> SupplyCategoriesXSupply { get; set; }

        //public virtual ICollection<SupplyModel> Supplies { get; set; }
    }
}
