
using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.GrammageCaliber;
using BusinessCape.DTOs.PaperCut;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.QuotationClientDetail;
using BusinessCape.DTOs.Substrate;
using DataCape.Models;

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
            //=======================|CLIENT|=======================//
            // POST OR CREATE //
            CreateMap<ClientCreateDto, ClientModel>();
            // PUT OR UPDATE //
            CreateMap<ClientUpdateDto, ClientModel>();
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

        }
    }
}
