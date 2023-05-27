using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class Client
    {
        public Client()
        {
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Center { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Regional { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
