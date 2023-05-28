using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.UnitMesureUpdate
{
    public class UnitMesureUpdate
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public int Type { get; set; }
        public long? BaseId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public bool? StatedAt { get; set; }

    }
}
