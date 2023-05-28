using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class PaperCutModel
    {
        public PaperCutModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
