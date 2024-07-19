namespace PriceLists.Data.Models;

public class Product : Entity
{
    public virtual string Name { get; set; }
    public virtual uint Code { get; set; }

    public virtual uint PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; }

    public virtual IEnumerable<ColumnValue> ColumnValues { get; set; }
}
