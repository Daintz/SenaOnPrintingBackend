namespace DataCape.Models
{
    public class SupplyXProductModel
    {
        public long? ProductId { get; set; }
        public long? SupplyId { get; set; }

        public virtual ProductModel? Product { get; set; }
        public virtual SupplyModel? Supply { get; set; }
    }
}
