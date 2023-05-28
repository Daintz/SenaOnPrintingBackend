using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Finish
    {
        public Finish()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long IdFinish { get; set; }
        public bool? StatedAt { get; set; }
        public string? FinishName { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
