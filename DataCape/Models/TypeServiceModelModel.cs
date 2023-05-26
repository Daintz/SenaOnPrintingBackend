using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class TypeServiceModelModel
    {
        public TypeServiceModelModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
