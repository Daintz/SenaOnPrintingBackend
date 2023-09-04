using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class FinishXProductModel
    {
        public long? ProductId { get; set; }
        public long? FinishId { get; set; }

        public virtual FinishModel? Finish { get; set; }
        public virtual ProductModel? Product { get; set; }
    }
}
