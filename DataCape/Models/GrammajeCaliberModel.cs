using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class GrammajeCaliberModel
    {
        public GrammajeCaliberModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long IdGrammajeCaliber { get; set; }
        public string TypeGrammajeCaliber { get; set; } = null!;
        public string GrammajeCaliber1 { get; set; } = null!;

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
