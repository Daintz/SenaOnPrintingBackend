namespace DataCape.Models
{
    public partial class UnitMeasuresXSupplyModel
    {
        public long IdUnitMeasure { get; set; }
        public long IdSupply { get; set; }

        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
        public virtual UnitMeasureModel IdUnitMeasureNavigation { get; set; } = null!;
    }
}
