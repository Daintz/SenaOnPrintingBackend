namespace DataCape.Models
{
    public partial class Role
    {
        public long IdRole { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
