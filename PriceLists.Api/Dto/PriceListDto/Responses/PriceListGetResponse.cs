using PriceLists.Data.Enums;
using PriceLists.Data.Extensions;

namespace PriceLists.Api.Dto.PriceListDto.Responses;

public class PriceListGetResponse
{
    public uint Id { get; set; }
    public string Name { get; set; } = null!;

    public IEnumerable<PriceListGetResponseProduct>? Products { get; set; }
    public IEnumerable<PriceListGetResponseColumn>? Columns { get; set; }
}

public class PriceListGetResponseColumn
{
    public uint Id { get; set; }
    public string Name { get; set; } = null!;
    public ColumnTypeValues Type { get; set; }
    public string TypeName => Type.GetNameOfColumnType();
}

public class PriceListGetResponseProduct
{
    public uint Id { get; set; }
    public string Name { get; set; } = null!;
    public uint Code { get; set; }

    public IEnumerable<PriceListGetResponseColumnValue>? ColumnValues { get; set; }
}

public class PriceListGetResponseColumnValue
{
    public uint Id { get; set; }
    public string Value { get; set; } = null!;
    public uint ColumnId { get; set; }
}