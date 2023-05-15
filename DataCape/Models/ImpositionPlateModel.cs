using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ImpositionPlateModel
    {
        public ImpositionPlateModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long IdImpositionPlate { get; set; }
        public string ImpositionPlateName { get; set; } = null!;
        public byte[] Scheme { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
