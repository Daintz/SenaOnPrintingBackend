using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class TypeServiceModelModel
    {
        public TypeServiceModelModel()
        {
            QuotationClients = new HashSet<QuotationClientModel>();
        }

<<<<<<< HEAD:DataCape/Models/TypeServiceModelModel.cs
        public long Id { get; set; }
=======
        public long IdTypeService { get; set; }
        public bool? StatedAt { get; set; } 
>>>>>>> 95dc0272dbf0fdf0da8f821efeeb82009668680d:DataCape/Models/TypeServiceModel.cs
        public string Name { get; set; } = null!;
        public bool? StatedAt { get; set; }

        public virtual ICollection<QuotationClientModel> QuotationClients { get; set; }
    }
}
