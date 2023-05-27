using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class Machine
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal? MinimumHeight { get; set; }
        public decimal? MinimumWidth { get; set; }
        public decimal? MaximumHeight { get; set; }
        public decimal? MaximumWidth { get; set; }
        public decimal? CostByUnit { get; set; }
        public decimal? CostByHour { get; set; }
        public bool? StatedAt { get; set; }
    }
}
