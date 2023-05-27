using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class GrammajeCaliber
    {
        public GrammajeCaliber()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdGrammajeCaliber { get; set; }
        public string TypeGrammajeCaliber { get; set; } = null!;
        public string GrammajeCaliber1 { get; set; } = null!;

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
