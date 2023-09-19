using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataCape.Models
{
    public class SupplyPictogramModel
    {
        public SupplyPictogramModel()
        {
            SupplyXSupplyPictogram = new List<SupplyXSupplyPictogramModel>();
        }

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PictogramFile { get; set; }
        public bool? StatedAt { get; set; }
        [JsonIgnore]
        public virtual List<SupplyXSupplyPictogramModel> SupplyXSupplyPictogram { get; set; }

        //public virtual ICollection<SupplyModel> Supplies { get; set; }
    }
}
