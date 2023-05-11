namespace DataCape.Models
{
    public partial class UnitMeasureModel
    {
        public long IdUnitMeasur { get; set; }
        public string Name { get; set; } = null!;
        public int Abbreviation { get; set; }
        public int Type { get; set; }
        public long? BaseId { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool? StatedAt { get; set; }
    }
}
