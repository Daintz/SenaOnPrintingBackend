using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class TypeServiceModel
    {
        public TypeServiceModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long IdTypeService { get; set; }
        public bool? StatedAt { get; set; } 
        public string Name { get; set; } = null!;

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
