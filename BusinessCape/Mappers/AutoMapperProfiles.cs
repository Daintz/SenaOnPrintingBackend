using AutoMapper;


using BusinessCape.DTOs.Machine;
using BusinessCape.DTOs.UnitMesureCreate;
using BusinessCape.DTOs.UnitMesureUpdate;
using DataCape;

using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Lineature;
using BusinessCape.DTOs.OrderProduction;
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
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.GrammageCaliber;
using BusinessCape.DTOs.PaperCut;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.QuotationClientDetail;
using BusinessCape.DTOs.Substrate;
using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.DTOs.TypeServices;
using BusinessCape.DTOs.SupplyPictograms;
using BusinessCape.DTOs.SupplyDetails;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            //=======================|Quotation Client Detail|=======================//
            // POST OR CREATE //
            CreateMap<QuotationClientDetailCreateDto, QuotationClientDetailModel>();
            // PUT OR UPDATE //
            CreateMap<QuotationClientDetailUpdateDto, QuotationClientDetailModel>();
            //=======================|Quotation Client|=======================//
            // POST OR CREATE //
            CreateMap<QuotationClientCreateDto, QuotationClientModel>();
            // PUT OR UPDATE //
            CreateMap<QuotationClientUpdateDto, QuotationClientModel>();



            //============================|ORDER PRODUCTION|==========================//
            // POST OR CREATE //
            CreateMap<OrderProductionCreateDto, OrderProductionModel>();
            // PUT OR UPDATE //
            CreateMap<OrderProductionUpdateDto, OrderProductionModel>();

            //============================|LINEATURE|==========================//
            // POST OR CREATE //
            CreateMap<LineatureCreateDto, LineatureModel>();
            // PUT OR UPDATE //
            CreateMap<LineatureUpdateDto, LineatureModel>();

            //============================|IMPOSITION PLANCH|==========================//
            // POST OR CREATE //
            CreateMap<ImpositionPlanchCreateDto, ImpositionPlanchModel>();
            // PUT OR UPDATE //
            CreateMap<ImpositionPlanchUpdateDto, ImpositionPlanchModel>();

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
            CreateMap<ClientCreateDto, ClientModel>();
            // PUT OR UPDATE //
            CreateMap<ClientUpdateDto, ClientModel>();

            //============================|Machine|==========================//
            CreateMap<MachineCreateDto, MachineModel>();
            CreateMap<MachineUpdateDto, MachineModel>();

            //============================|Finish|==========================//


            CreateMap<FinishDtoCreate, FinishModel>();

            CreateMap<FinishDtoUpdate, FinishModel>();

            CreateMap<UnitMesureCreate, UnitMeasureModel>();

            CreateMap<UnitMesureUpdate, UnitMeasureModel>();




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

            //=======================|GRAMMAGE CALIBER|=======================//
            // POST OR CREATE //
            CreateMap<GrammageCaliberCreateDto, GrammageCaliberModel>();
            // PUT OR UPDATE //
            CreateMap<GrammageCaliberUpdateDto, GrammageCaliberModel>();
            //=======================|PAPER CUT|=======================//
            // POST OR CREATE //
            CreateMap<PaperCutCreateDto, PaperCutModel>();
            // PUT OR UPDATE //
            CreateMap<PaperCutUpdateDto, PaperCutModel>();
            //=======================|SUBSTRATES|=======================//
            // POST OR CREATE //
            CreateMap<SubstrateCreateDto, SubstrateModel>();
            // PUT OR UPDATE //
            CreateMap<SubstrateUpdateDto, SubstrateModel>();
            //========================|QUOTATION PROVIDER|===================//
            // POST OR CREATE //
            CreateMap<QuotationProvidersCreateDto, QuotationProviderModel>();
            // PUT OR UPDATE //
            CreateMap<QuotationProvidersUpdateDto, QuotationProviderModel>();
            //============================|TYPE SERVICES|=======================//
            // POST OR CREATE //
            CreateMap<TypeServicesCreateDto, TypeServiceModel>();
            // PUT OR UPDATE //
            CreateMap<TypeServicesUpdateDto, TypeServiceModel>();
            //===========================|SUPPLY PICTOGRMAS|=========================//
            // POST OR CREATE //
            CreateMap<SupplyPictogramsCreateDto, SupplyPictogramModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyPictogramsUpdateDto, SupplyPictogramModel>();
            //SupplyDetails //
            // POST OR CREATE //
            CreateMap<SupplyDetailsCreateDto, SupplyDetailModel>();
            // PUT OR UPDATE //
            CreateMap<SupplyDetailsUpdateDto, SupplyDetailModel>();

        }
    }
}