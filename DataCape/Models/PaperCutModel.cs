using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class PaperCutModel
    {
        public PaperCutModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long IdPaperCut { get; set; }
        public string PaperCut1 { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
