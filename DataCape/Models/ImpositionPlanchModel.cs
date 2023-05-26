using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class ImpositionPlanchModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Scheme { get; set; }
        public bool? StatedAt { get; set; }
    }
}
