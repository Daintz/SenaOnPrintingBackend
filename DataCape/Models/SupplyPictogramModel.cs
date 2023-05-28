using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyPictogramModel
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? PictogramFile { get; set; }
        public bool? StatedAt { get; set; }
    }
}
