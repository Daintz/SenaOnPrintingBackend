using AutoMapper;
using BusinessCape.DTOs.SupplyCategory;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //=======================|SUPPLY CATEGORY|=======================//
            // POST OR CREATE
            CreateMap<SupplyCategoryCreateDto, SupplyCategoryModel>();
            // PUT OR UPDATE
            CreateMap<SupplyCategoryUpdateDto, SupplyCategoryModel>();
        }
    }
}
