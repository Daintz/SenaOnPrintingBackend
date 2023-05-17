﻿using AutoMapper;

using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyCategory;

using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
          
            

            //=======================|Quotation Client|=======================//
            // POST OR CREATE //
            CreateMap<QuotationCreateDto, QuotationClientModel>();
            // PUT OR UPDATE //
            CreateMap<QuotationUpdateDto, QuotationClientModel>();
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
