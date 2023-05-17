using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.TypeDocument;
using BusinessCape.DTOs.User;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //=======================|SUPPLY CATEGORY|=======================//
            // POST OR CREATE //
            CreateMap<SupplyCategoryCreateDto, SupplyCategory>();
            // PUT OR UPDATE //
            CreateMap<SupplyCategoryUpdateDto, SupplyCategory>();

            //============================|SUPPLY|==========================//
            // POST OR CREATE //
            CreateMap<SupplyCreateDto, Supply>();
            // PUT OR UPDATE //
            CreateMap<SupplyUpdateDto, Supply>();

            //============================|ROLE|==========================//
            // POST OR CREATE //
            CreateMap<RoleCreateDto, Role>();
            // PUT OR UPDATE //
            CreateMap<RoleUpdateDto, Role>();

            //============================|TYPE DOCUMENT|==========================//
            // POST OR CREATE //
            CreateMap<TypeDocumentCreateDto, TypeDocument>();
            // PUT OR UPDATE //
            CreateMap<TypeDocumentUpdateDto, TypeDocument>();

            //============================|USER|==========================//
            // POST OR CREATE //
            CreateMap<UserCreateDto, User>();
            // PUT OR UPDATE //
            CreateMap<UserUpdateDto, User>();
        }
    }
}
