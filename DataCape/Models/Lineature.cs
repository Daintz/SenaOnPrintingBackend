using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Lineature
    {
        public Lineature()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdLineature { get; set; }
        public string Lineature1 { get; set; } = null!;
        public string TypePoint { get; set; } = null!;
        public string Other { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
