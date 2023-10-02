using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCape.Models
{
    public class SupplySupplyDetailsModel
    {
        public long Id { get; set; }
        public long? SupplyId { get; set; }
        public long? supplydetails_id { get; set; }
        public int? Quantity { get; set; }
        public decimal? SupplyCost { get; set; }
        [NotMapped]
        public string SupplyName { get; set; } = null!;

        public virtual SupplyModel? Supply { get; set; }
        public virtual SupplyDetailModel? SupplyDetail { get; set; }

    }
}
