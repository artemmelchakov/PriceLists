using PriceLists.Data.Enums;

namespace PriceLists.Data.Models;

public class Column : Entity
{
    public Column() => PriceLists = new HashSet<PriceList>();

    public virtual string Name { get; set; } = null!;
    public virtual ColumnTypeValues Type { get; set; }

    public virtual IEnumerable<ColumnValue>? ColumnValues { get; set; }
    public virtual IEnumerable<PriceList> PriceLists { get; set; }
}
