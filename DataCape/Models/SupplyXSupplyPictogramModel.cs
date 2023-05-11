namespace DataCape.Models
{
    public partial class SupplyXSupplyPictogramModel
    {
        public long IdSupply { get; set; }
        public long IdSupplyPictogram { get; set; }

        public virtual SupplyModel IdSupplyNavigation { get; set; } = null!;
        public virtual SupplyPictogramModel IdSupplyPictogramNavigation { get; set; } = null!;
    }
}
