using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SubstrateModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
