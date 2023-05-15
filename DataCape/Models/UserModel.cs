using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class UserModel
    {
        public UserModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
            QuotationClients = new HashSet<QuotationClientModel>();
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

        public virtual RoleModel IdRoleNavigation { get; set; } = null!;
        public virtual TypeDocumentModel IdTypeDocumentNavigation { get; set; } = null!;
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
