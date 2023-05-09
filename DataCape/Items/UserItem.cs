using System.ComponentModel.DataAnnotations;

namespace DataCape.Items
{
    public partial class UserItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
