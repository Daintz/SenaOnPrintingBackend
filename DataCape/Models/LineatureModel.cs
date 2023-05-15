using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class LineatureModel
    {
        public LineatureModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long IdLineature { get; set; }
        public string Lineature1 { get; set; } = null!;
        public string TypePoint { get; set; } = null!;
        public string Other { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
