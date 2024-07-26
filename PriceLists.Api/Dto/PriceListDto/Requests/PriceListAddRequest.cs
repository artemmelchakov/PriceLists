using PriceLists.Data.Enums;

namespace PriceLists.Api.Dto.PriceListDto.Requests;

public class PriceListAddRequest
{
    public string Name { get; set; }
    public virtual IEnumerable<PriceListAddRequestColumn> Columns { get; set; }
}

public class PriceListAddRequestColumn
{
    public uint? Id { get; set; }
    public string Name { get; set; }
    public ColumnTypeValues Type { get; set; }
}
