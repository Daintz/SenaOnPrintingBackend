using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Lineature;
using BusinessCape.DTOs.OrderProduction;

using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            

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
        }
    }
}
