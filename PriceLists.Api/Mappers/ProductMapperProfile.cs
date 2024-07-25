using AutoMapper;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data.Models;

namespace PriceLists.Api.Mappers;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, PriceListGetResponseProduct>();

        CreateMap<ProductAddRequest, Product>();
    }
}
