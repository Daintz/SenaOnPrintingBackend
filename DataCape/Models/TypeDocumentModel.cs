namespace DataCape.Models
{
    public partial class TypeDocumentModel
    {
        public long IdTypeDocument { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
