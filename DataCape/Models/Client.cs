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

        public long IdClient { get; set; }
        public bool? StatedAt { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Center { get; set; }
        public string? Area { get; set; }
        public string? Regional { get; set; }

        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
