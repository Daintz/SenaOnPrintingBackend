using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class UserModelModel
    {
        public UserModelModel()
        {
            OrderProductions = new HashSet<OrderProductionModel>();
            QuotationClients = new HashSet<QuotationClientModel>();
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
<<<<<<< HEAD:DataCape/Models/UserModelModel.cs
        public bool? StatedAt { get; set; }
=======
        public long IdRole { get; set; }
        public long IdTypeDocument { get; set; }
        public bool? StatedAt { get; set; } 
>>>>>>> 95dc0272dbf0fdf0da8f821efeeb82009668680d:DataCape/Models/UserModel.cs

        public virtual RoleModel Role { get; set; } = null!;
        public virtual TypeDocumentModel TypeDocument { get; set; } = null!;
        public virtual ICollection<OrderProductionModel> OrderProductions { get; set; }
        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
