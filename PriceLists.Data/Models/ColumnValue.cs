namespace PriceLists.Data.Models;

public class ColumnValue : Entity
{
    public virtual string Value { get; set; }

    public virtual uint ColumnId { get; set; }
    public virtual Column Column { get; set; }

    public virtual uint PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; }

    public virtual uint ProductId { get; set; }
    public virtual Product Product { get; set; }
}
