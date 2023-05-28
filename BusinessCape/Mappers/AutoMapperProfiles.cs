using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.DTOs.TypeDocument;
using BusinessCape.DTOs.User;
using BusinessCape.DTOs.Provider;
using BusinessCape.DTOs.Warehause;
using BusinessCape.DTOs.WarehauseType;
//using BusinessCape.DTOs.ImpositionPlate;
//using BusinessCape.DTOs.Lineature;
//using BusinessCape.DTOs.OrderProduction;
//using BusinessCape.DTOs.Client;
//using BusinessCape.DTOs.Finish;
//using BusinessCape.DTOs.Machine;
//using BusinessCape.DTOs.QuotationClient;
//using BusinessCape.DTOs.Supply;
//using BusinessCape.DTOs.SupplyCategory;
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

            //=======================|CLIENT|=======================//
            // POST OR CREATE //
            //CreateMap<ClientCreateDto, ClientModel>();
            // PUT OR UPDATE //
            //CreateMap<ClientUpdateDto, ClientModel>();

            //============================|Machine|==========================//
            //CreateMap<MachineCreateDto, MachineModel>();
            //CreateMap<MachineUpdateDto, MachineModel>();

            //============================|Finish|==========================//
            //CreateMap<FinishDtoCreate, FinishModel>();
            //CreateMap<FinishDtoUpdate, FinishModel>();
            //CreateMap<FinishDtoUpdate_state, FinishModel>();

            //=======================|Quotation Client|=======================//
            // POST OR CREATE //
            //CreateMap<QuotationCreateDto, QuotationClientModel>();
            // PUT OR UPDATE //
            //CreateMap<QuotationUpdateDto, QuotationClientModel>();
            // PUT OR UPDATE STATUS //
            //CreateMap<QuotationUpdateStatusDTO, QuotationClientModel>();
            
            //============================|PROVIDERS|==========================//
            // POST OR CREATE //
            CreateMap<ProviderCreateDto, ProviderModel>();
            // PUT OR UPDATE //
            CreateMap<ProviderUpdateDto, ProviderModel>();
            
            //============================|WarehauseType|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseTypeCreateDto, WarehouseTypeModel>();
            // PUT OR UPDATE //
            CreateMap<WarehauseTypeUpdateDto, WarehouseTypeModel>();
            
            //============================|Warehause|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseCreateDto, WarehouseModel>();
            // PUT OR UPDATE //
            CreateMap<WarehauseUpdateDto, WarehouseModel>();

            //============================|ORDER PRODUCTION|==========================//
            // POST OR CREATE //
            //CreateMap<OrderProductionCreateDto, OrderProductionModel>();
            // PUT OR UPDATE //
            //CreateMap<OrderProductionUpdateDto, OrderProductionModel>();

            //============================|LINEATURE|==========================//
            // POST OR CREATE //
            //CreateMap<LineatureCreateDto, LineatureModel>();
            // PUT OR UPDATE //
            //CreateMap<LineatureUpdateDto, LineatureModel>();

            //============================|IMPOSITION PLATE|==========================//
            // POST OR CREATE //
            //CreateMap<ImpositionPlateCreateDto, ImpositionPlanchModel>();
            // PUT OR UPDATE //
            //CreateMap<ImpositionPlanchUpdateDto, ImpositionPlanchModel>();
        }
    }
}
