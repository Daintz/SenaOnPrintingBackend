using AutoMapper;


using BusinessCape.DTOs.Machine;
using BusinessCape.DTOs.UnitMesureCreate;
using BusinessCape.DTOs.UnitMesureUpdate;
using DataCape;

using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.OrderProduction;
using BusinessCape.DTOs.Role;
using BusinessCape.DTOs.TypeDocument;
using BusinessCape.DTOs.User;
using BusinessCape.DTOs.Provider;
using BusinessCape.DTOs.Warehause;
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
using BusinessCape.DTOs.PaperCut;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.QuotationClientDetail;
using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.DTOs.TypeServices;
using BusinessCape.DTOs.SupplyPictograms;
using BusinessCape.DTOs.BuySupply;
using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.DTOs.Product;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.Supply;

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

            //============================|IMPOSITION PLANCH|==========================//
            // POST OR CREATE //
            CreateMap<ImpositionPlanchCreateDto, ImpositionPlanchModel>();
            // PUT OR UPDATE //
            CreateMap<ImpositionPlanchUpdateDto, ImpositionPlanchModel>();

            //============================|ROLE|==========================//
            // POST OR CREATE //

            CreateMap<RoleCreateDto, RoleModel>();
                //.ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
            // PUT OR UPDATE //
            CreateMap<RoleUpdateDto, RoleModel>();
                //.ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));


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


            //============================|Warehause|==========================//
            // POST OR CREATE //
            CreateMap<WarehauseCreateDto, WarehouseModel>();
            // PUT OR UPDATE //
            CreateMap<WarehauseUpdateDto, WarehouseModel>();

            //=======================|PAPER CUT|=======================//
            // POST OR CREATE //
            CreateMap<PaperCutCreateDto, PaperCutModel>();
            // PUT OR UPDATE //
            CreateMap<PaperCutUpdateDto, PaperCutModel>();

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

            //SUPPLY PURCHASE //
            // POST OR CREATE //
            CreateMap<BuySuppliesCreateDto, BuySupplyModel>();
            // PUT OR UPDATE //
            CreateMap<BuySuppliesUpdateDto, BuySupplyModel>();

            //SUPPLY PURCHASE DETAIL//
            // POST OR CREATE //
            CreateMap<BuySuppliesDetailsCreateDto, BuySuppliesDetailModel>();
            // PUT OR UPDATE //
            CreateMap<BuySuppliesDetailsUpdateDto, BuySuppliesDetailModel>();

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

        }
    }
}