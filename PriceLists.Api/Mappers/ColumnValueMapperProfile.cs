using AutoMapper;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data.Models;

namespace PriceLists.Api.Mappers;

public class ColumnValueMapperProfile : Profile
{
    public ColumnValueMapperProfile()
    {
        CreateMap<ColumnValue, PriceListGetResponseColumnValue>();

        CreateMap<ProductAddRequestColumnValue, ColumnValue>();
    }
}
