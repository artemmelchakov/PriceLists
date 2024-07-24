using AutoMapper;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data.Models;
using RColumn = PriceLists.Api.Dto.PriceListDto.Requests.PriceListAddRequest.Column;

namespace PriceLists.Api.Mappers;

public class ColumnMapperProfile : Profile
{
    public ColumnMapperProfile()
    {
        CreateMap<Column, ColumnGetAllResponse>();
        CreateMap<RColumn, Column>();
    }
}
