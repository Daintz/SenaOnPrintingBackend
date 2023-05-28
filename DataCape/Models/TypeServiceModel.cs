using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class TypeServiceModel
    {
        public TypeServiceModel()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
