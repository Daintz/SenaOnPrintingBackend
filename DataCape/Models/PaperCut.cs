using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class PaperCut
    {
        public PaperCut()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
