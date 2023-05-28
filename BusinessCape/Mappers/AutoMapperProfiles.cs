using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.DTOs.TypeDocument;
using BusinessCape.DTOs.User;
using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //============================|ROLE|==========================//
            // POST OR CREATE //
            CreateMap<RoleCreateDto, RoleModel>();
            // PUT OR UPDATE //
            CreateMap<RoleUpdateDto, RoleModel>();

            //============================|TYPE DOCUMENT|==========================//
            // POST OR CREATE //
            CreateMap<TypeDocumentCreateDto, TypeDocumentModel>();
            // PUT OR UPDATE //
            CreateMap<TypeDocumentUpdateDto, TypeDocumentModel>();

            //============================|USER|==========================//
            // POST OR CREATE //
            CreateMap<UserCreateDto, UserModel>();
            // PUT OR UPDATE //
            CreateMap<UserUpdateDto, UserModel>();
        }
    }
}
