using DataCape.Models;

namespace BusinessCape.DTOs.Role
{
    public class RoleCreateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<long> PermissionIds { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
