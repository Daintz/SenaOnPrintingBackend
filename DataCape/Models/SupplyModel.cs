﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataCape.Models
{
    public class SupplyModel
    {
        public SupplyModel()
        {
            SupplyCategoriesXSupply = new List<SupplyCategoriesXSupplyModel>();
            SupplyXSupplyPictogram = new List<SupplyXSupplyPictogramModel>();
            UnitMeasuresXSupply = new List<UnitMeasuresXSupplyModel>();
            //SupplyDetails = new List<SupplyDetailModel>();
            Products = new List<SupplyXProductModel>();
            BuySuppliesDetails = new List<BuySuppliesDetailModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string DangerIndicators { get; set; }
        public string UseInstructions { get; set; }
        public string Advices { get; set; }
        public int SupplyType { get; set; }
        public int SortingWord { get; set; }
        public int? Quantity { get; set; }
        public decimal? AverageCost { get; set; }

        public bool? StatedAt { get; set; }
        //public long? UnitMeasuresId { get; set; }
        //public long? SupplyPictogramsId { get; set; }
        //public long? SupplyCategoriesId { get; set; }

        //public virtual SupplyCategoryModel? SupplyCategories { get; set; }
        //public virtual SupplyPictogramModel? SupplyPictograms { get; set; }
        //public virtual UnitMeasureModel? UnitMeasures { get; set; }
        public virtual List<SupplyCategoriesXSupplyModel> SupplyCategoriesXSupply { get; set; }        
        public virtual List<SupplyXSupplyPictogramModel> SupplyXSupplyPictogram { get; set; }        
        public virtual List<UnitMeasuresXSupplyModel> UnitMeasuresXSupply { get; set; }

        //[JsonIgnore]
        //public virtual SupplyCategoryModel? SupplyCategoryNavigation { get; set; }
        //public virtual SupplyPictogramModel? SupplyPictogram { get; set; }
        //public virtual UnitMeasureModel? UnitMeasure { get; set; }

        //public virtual List<SupplyDetailModel> SupplyDetails { get; set; }
        public virtual List<SupplyXProductModel> Products { get; set; }
        [JsonIgnore]
        public virtual List<BuySuppliesDetailModel> BuySuppliesDetails { get; set; }

    }
}
