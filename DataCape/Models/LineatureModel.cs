using System;
using System.Collections.Generic;

namespace DataCape
{
    public class LineatureModel
    {
        public long Id { get; set; }
        public string Lineature1 { get; set; } = null!;
        public string? TypePoint { get; set; }
        public bool? StatedAt { get; set; }
    }
}
