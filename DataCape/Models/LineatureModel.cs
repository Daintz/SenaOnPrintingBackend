using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class LineatureModel
    {
        public long Id { get; set; }
        public string Lineature { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
