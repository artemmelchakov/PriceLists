using AutoMapper;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data.Models;

namespace PriceLists.Api.Mappers;

public class ColumnMapperProfile : Profile
{
    public ColumnMapperProfile()
    {
        CreateMap<Column, ColumnGetAllResponse>();
        CreateMap<Column, PriceListGetResponseColumn>();        

        CreateMap<PriceListAddRequestColumn, Column>();
    }
}
