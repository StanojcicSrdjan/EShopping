﻿using AutoMapper;
using ShopManagement.Common.Models.DataBase;
using ShopManagement.Common.Models.Inbound;
using ShopManagement.Common.Models.Outbound;

namespace ShopManagement.Common.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<NewProduct, Product>()
                .ForMember(dest => dest.SellerId, opt => opt.MapFrom(src => new Guid(src.SellerId)))
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));

            CreateMap<UpdateProduct, Product>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.ProductId)));        

            CreateMap<Product, ProductView>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image == null? null : $"data:image/jpg;base64,{Convert.ToBase64String(src.Image)}"));
            
        }
    }
}