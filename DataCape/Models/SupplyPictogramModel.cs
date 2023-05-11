namespace DataCape.Models
{
    public partial class SupplyPictogramModel
    {
        public long IdPictogram { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Pictogram { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
