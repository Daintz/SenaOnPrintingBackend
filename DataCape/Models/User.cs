using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class User
    {
        public User()
        {
            OrderProductions = new HashSet<OrderProduction>();
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long IdUser { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Surnames { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordDigest { get; set; } = null!;
        public long IdRole { get; set; }
        public long IdTypeDocument { get; set; }
        public bool? StatedAt { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual TypeDocument IdTypeDocumentNavigation { get; set; } = null!;
        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
