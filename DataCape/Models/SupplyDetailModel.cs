
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCape.Models
{
    public class SupplyDetailModel
    {
        public SupplyDetailModel()
        {
            Supplies = new List<SupplySupplyDetailsModel>();
        }
        public long Id { get; set; }
        public long? ProviderId { get; set; }
        public string? Description { get; set; }
        public DateTime EntryDate { get; set; }
        //public string? security_file { get; set; }
        public float? FullValue { get; set; }
        public bool? StatedAt { get; set; }


       
        public virtual List<SupplySupplyDetailsModel> Supplies { get; set; }
        public virtual ProviderModel? Provider { get; set; }
    }
}
