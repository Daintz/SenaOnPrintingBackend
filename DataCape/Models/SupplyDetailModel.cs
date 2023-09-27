
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyDetailModel
    {
        public SupplyDetailModel()
        {
            Supply = new List<SupplySupplyDetailsModel>();
        }
        public long Id { get; set; }
        public long? ProviderId { get; set; }
        public string? Description { get; set; }
        public DateTime EntryDate { get; set; }
        //public string? security_file { get; set; }
        public float? FullValue { get; set; }
        public bool? StatedAt { get; set; }


        [JsonIgnore]
        public virtual List<SupplySupplyDetailsModel> Supply { get; set; }
        public virtual ProviderModel? Provider { get; set; }
        public long? SupplyDetailsId { get; set; }
    }
}
