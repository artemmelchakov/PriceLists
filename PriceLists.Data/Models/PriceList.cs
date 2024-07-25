namespace PriceLists.Data.Models;

public class PriceList : Entity
{
    public virtual string Name { get; set; } = null!;

    public virtual IEnumerable<Product>? Products { get; set; }
    public virtual IEnumerable<Column>? Columns { get; set; }
}
