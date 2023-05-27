using AutoMapper;
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
       
            //============================|PROVIDERS|==========================//
            // POST OR CREATE //
            CreateMap<ProviderCreateDto, Provider>();
            // PUT OR UPDATE //
            CreateMap<ProviderUpdateDto, Provider>();
            //============================|WarehauseType|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseTypeCreateDto,WarehouseType>();
            // PUT OR UPDATE //
            CreateMap<WarehauseTypeUpdateDto, WarehouseType>();
            //============================|Warehause|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseCreateDto, Warehouse>();
            // PUT OR UPDATE //
            CreateMap<WarehauseUpdateDto, Warehouse>();

        }
    }
}
