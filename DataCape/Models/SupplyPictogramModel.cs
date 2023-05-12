using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class SupplyPictogramModel
    {
        public Guid IdPictogram { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Pictogram { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
