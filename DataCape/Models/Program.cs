using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Program
    {
        public Program()
        {
            OrderProductions = new HashSet<OrderProduction>();
        }

        public long IdProgram { get; set; }
        public long ProgramName { get; set; }
        public bool? StatedAt { get; set; }

        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
    }
}
