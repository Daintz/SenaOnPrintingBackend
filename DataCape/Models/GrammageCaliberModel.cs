using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class GrammageCaliberModel
    {
        public long Id { get; set; }
        public string Type { get; set; } = null!;
        public string? Name { get; set; }
        public bool? StatedAt { get; set; }
    }
}
