using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Machine
    {
        public Machine()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long IdMachine { get; set; }
        public bool? StatedAt { get; set; }
        public string? Name { get; set; }
        public decimal? MinimumHeight { get; set; }
        public decimal? MinimumWidth { get; set; }
        public decimal? MaximumHeight { get; set; }
        public decimal? MaximumWidth { get; set; }
        public decimal? CostByUnit { get; set; }
        public decimal? CostByHour { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
