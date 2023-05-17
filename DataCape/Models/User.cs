using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public long? TypeDocumentId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string Surnames { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public long? RoleId { get; set; }
        public bool? StatedAt { get; set; }
        public string PasswordDigest { get; set; } = null!;

        public virtual Role? Role { get; set; }
        public virtual TypeDocument? TypeDocument { get; set; }
    }
}
