using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class TypeService
    {
        public TypeService()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long IdTypeService { get; set; }
        public bool? StatedAt { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
