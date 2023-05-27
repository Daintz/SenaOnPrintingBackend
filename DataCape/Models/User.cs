using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class User
    {
        public User()
        {
            OrderProductions = new HashSet<OrderProduction>();
            QuotationClients = new HashSet<QuotationClient>();
        }

        public long Id { get; set; }
        public long TypeDocumentId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string Surnames { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public long RoleId { get; set; }
        public string PasswordDigest { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual TypeDocument TypeDocument { get; set; } = null!;
        public virtual ICollection<OrderProduction> OrderProductions { get; set; }
        public virtual ICollection<QuotationClient> QuotationClients { get; set; }
    }
}
