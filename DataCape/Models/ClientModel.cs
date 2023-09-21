using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataCape.Models
{
    public class ClientModel
    {
        public ClientModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Center { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Regional { get; set; } = null!;
        public bool? StatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
