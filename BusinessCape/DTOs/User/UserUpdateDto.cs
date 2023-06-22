using DataCape.Models;

namespace BusinessCape.DTOs.User
{
    public class UserUpdateDto
    {
        public long Id { get; set; }
        public long? TypeDocumentId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public long? RoleId { get; set; }
        public bool? StatedAt { get; set; }
        public string PasswordDigest { get; set; }

    }
}
