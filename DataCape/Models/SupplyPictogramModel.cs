using System;
using System.Collections.Generic;

namespace DataCape.Models
{
    public class SupplyPictogramModel
    {
        //public SupplyPictogramModel()
        //{
        //    Supplies = new HashSet<SupplyModel>();
        //}

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PictogramFile { get; set; }
        public bool? StatedAt { get; set; }

       // public virtual ICollection<SupplyModel> Supplies { get; set; }
    }
}
