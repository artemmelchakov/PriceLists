using AutoMapper;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data.Models;

namespace PriceLists.Api.Mappers;

public class PriceListMapperProfile : Profile
{
    public PriceListMapperProfile()
    {
        CreateMap<PriceList, PriceListGetAllResponse>();

        CreateMap<PriceListAddRequest, PriceList>().ForMember(d => d.Columns, o => o.Ignore());
    }
}
