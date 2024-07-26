using PriceLists.Data.Enums;

namespace PriceLists.WebApp.Models;

public class ProductAddViewModel
{
    public uint PriceListId { get; set; }
    public IEnumerable<ProductAddViewModelColumn>? Columns { get; set; }
}

public class ProductAddViewModelColumn
{
    public uint Id { get; set; }
    public string Name { get; set; } = null!;
    public ColumnTypeValues Type { get; set; }
    public string TypeName { get; set; } = null!;
}