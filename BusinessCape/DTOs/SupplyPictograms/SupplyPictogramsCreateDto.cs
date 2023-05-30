using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.SupplyPictograms
{
    public class SupplyPictogramsCreateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? PictogramFile { get; set; }
        public bool? StatedAt { get; set; }
    }

}
