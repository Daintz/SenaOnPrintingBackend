using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PaperCut
    {
        public PaperCut()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdPaperCut { get; set; }
        public string PaperCut1 { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
