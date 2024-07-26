using PriceLists.Data.Extensions;
using PriceLists.Data.Enums;

namespace PriceLists.Api.Dto.PriceListDto.Responses;

public class ColumnGetAllResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public ColumnTypeValues Type { get; set; }
    public string TypeName => Type.GetNameOfColumnType();
}
