using System;
using System.Collections.Generic;

namespace DataCape
{
    public  class SupplyPictogramModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? PictogramFile { get; set; }
        public bool? StatedAt { get; set; }
    }
}
