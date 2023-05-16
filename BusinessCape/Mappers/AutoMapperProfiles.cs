using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //=======================|CLIENT|=======================//
            // POST OR CREATE //
            CreateMap<ClientCreateDto, ClientModel>();
            // PUT OR UPDATE //
            CreateMap<ClientUpdateDto, ClientModel>();

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
        }
    }
}
