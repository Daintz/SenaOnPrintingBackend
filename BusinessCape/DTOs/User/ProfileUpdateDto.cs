using DataCape.Models;

namespace BusinessCape.DTOs.User
{
    public class ProfileUpdateDto
    {
        public long Id { get; set; }
        public long TypeDocumentId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }        
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
