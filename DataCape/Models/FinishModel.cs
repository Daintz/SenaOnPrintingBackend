using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class FinishModel
    {
<<<<<<< HEAD
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }
=======
        public FinishModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

        public long IdFinish { get; set; }
        public bool? StatedAt { get; set; } = true;
        public string? FinishName { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
>>>>>>> 95dc0272dbf0fdf0da8f821efeeb82009668680d
    }
}
