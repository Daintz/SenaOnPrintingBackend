using DataCape.Models;

namespace BusinessCape.DTOs.User
{
    public class UserCreateDto
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
    }
}
