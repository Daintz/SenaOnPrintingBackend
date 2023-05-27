using System;
using System.Collections.Generic;

namespace DataCape
{
    public partial class MachinesXQuotationClient
    {
        public long? QuotationClientId { get; set; }
        public long? MachineId { get; set; }

        public virtual Machine? Machine { get; set; }
        public virtual QuotationClient? QuotationClient { get; set; }
    }
}
