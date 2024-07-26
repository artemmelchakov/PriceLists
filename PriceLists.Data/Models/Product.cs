namespace PriceLists.Data.Models;

public class Product : Entity
{
    public virtual string Name { get; set; } = null!;
    public virtual uint Code { get; set; }

    public virtual uint PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; } = null!;

    public virtual IEnumerable<ColumnValue>? ColumnValues { get; set; }
}