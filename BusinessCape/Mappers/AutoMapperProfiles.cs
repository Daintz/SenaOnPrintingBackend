using AutoMapper;
using BusinessCape.DTOs.Product;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.SupplyDetails;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //============================|PRODUCT|==========================//
            // POST OR CREATE //
            CreateMap<ProductCreateDto, ProductModel>();
            // PUT OR UPDATE //
            CreateMap<ProductUpdateDto, ProductModel>();
            //==============================================================//

            //=======================|SUPPLY CATEGORY|=======================//
            // POST OR CREATE //
            CreateMap<SupplyCategoryCreateDto, SupplyCategoryModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyCategoryUpdateDto, SupplyCategoryModel>();
            //==============================================================//

            //============================|SUPPLY|==========================//
            // POST OR CREATE //
            CreateMap<SupplyCreateDto, SupplyModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyUpdateDto, SupplyModel>();
            //==============================================================//

            //SupplyDetails //
            // POST OR CREATE //
            CreateMap<SupplyDetailsCreateDto, SupplyDetailModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyDetailsUpdateDto, SupplyDetailModel>();
        }
    }
}
