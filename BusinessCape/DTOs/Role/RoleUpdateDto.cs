using DataCape.Models;

namespace BusinessCape.DTOs.Role
{
    public class RoleUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? StatedAt { get; set; }
    }
}
