using AutoMapper;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.Provider;
using BusinessCape.DTOs.Warehause;
using BusinessCape.DTOs.WarehauseType;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //=======================|SUPPLY CATEGORY|=======================//
            // POST OR CREATE //
            CreateMap<SupplyCategoryCreateDto, SupplyCategoryModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyCategoryUpdateDto, SupplyCategoryModel>();

            //============================|SUPPLY|==========================//
            // POST OR CREATE //
            CreateMap<SupplyCreateDto, SupplyModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyUpdateDto, SupplyModel>();
            //============================|PROVIDERS|==========================//
            // POST OR CREATE //
            CreateMap<ProviderCreateDto, ProviderModel>();
            // PUT OR UPDATE //
            CreateMap<ProviderUpdateDto, ProviderModel>();
            //============================|WarehauseType|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseTypeCreateDto,WarehouseTypeModel>();
            // PUT OR UPDATE //
            CreateMap<WarehauseTypeUpdateDto, WarehouseTypeModel>();
            //============================|Warehause|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseCreateDto, WarehouseModel>();
            // PUT OR UPDATE //
            CreateMap<WarehauseUpdateDto, WarehouseModel>();

        }
    }
}
