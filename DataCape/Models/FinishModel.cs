using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class FinishModel
    {
        public FinishModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long IdFinish { get; set; }
        public bool? StatedAt { get; set; } = true;
        public string? FinishName { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
