namespace PriceLists.Api.Dto.PriceListDto.Requests;

public class ProductAddRequest
{
    public string Name { get; set; } = null!;
    public uint Code { get; set; }
    public uint PriceListId { get; set; }

    public IEnumerable<ProductAddRequestColumnValue>? ColumnValues { get; set; }
}

public class ProductAddRequestColumnValue
{
    public string Value { get; set; } = null!;
    public uint ColumnId { get; set; }

    //public virtual uint PriceListId { get; set; }
    //public virtual PriceList PriceList { get; set; }

    //public virtual uint ProductId { get; set; }
    //public virtual Product Product { get; set; }
}
