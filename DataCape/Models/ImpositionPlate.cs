using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ImpositionPlate
    {
        public ImpositionPlate()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdImpositionPlate { get; set; }
        public string ImpositionPlateName { get; set; } = null!;
        public byte[] Scheme { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
