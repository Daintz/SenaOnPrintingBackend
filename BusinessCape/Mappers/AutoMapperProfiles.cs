using AutoMapper;

using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.Machine;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;

using DataCape;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            //============================|Machine|==========================//

            CreateMap<MachineCreateDto, MachineModel>();

            CreateMap<MachineUpdateDto, MachineModel>();

            //============================|Finish|==========================//

            CreateMap<FinishDtoCreate, FinishModel>();

            CreateMap<FinishDtoUpdate, FinishModel>();
       

            //=======================|Quotation Client|=======================//
            // POST OR CREATE //
            CreateMap<QuotationCreateDto, QuotationClientModel>();
            // PUT OR UPDATE //
            CreateMap<QuotationUpdateDto, QuotationClientModel>();
            // PUT OR UPDATE STATUS //
            CreateMap<QuotationUpdateStatusDTO, QuotationClientModel>();
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
