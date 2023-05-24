using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class TypeDocument
    {
        public long IdTypeDocument { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual User? User { get; set; }
    }
}
