using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class ProgramModel
    {
        public ProgramModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
        }

        public long IdProgram { get; set; }
        public long ProgramName { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
    }
}
