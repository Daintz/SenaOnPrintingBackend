using System;
using System.Collections.Generic;

namespace DataCape
{
    public  class MachinesXQuotationClientModel
    {
        public long? QuotationClientId { get; set; }
        public long? MachineId { get; set; }

        public virtual MachineModel? Machine { get; set; }
        public virtual QuotationClientModel? QuotationClient { get; set; }
    }
}
