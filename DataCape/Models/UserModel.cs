namespace DataCape.Models
{
    public partial class UserModel
    {
        public long IdUser { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string Surnames { get; set; } = null!;
        public long LastNames { get; set; }
        public long Phone { get; set; }
        public long Address { get; set; }
        public long Email { get; set; }
        public long PasswordDigest { get; set; }
        public long IdRole { get; set; }
        public long IdTypeDocument { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual TypeDocumentModel IdTypeDocumentNavigation { get; set; } = null!;
    }
}
