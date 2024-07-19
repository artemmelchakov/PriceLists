using PriceLists.Data.Enums;

namespace PriceLists.Data.Models;

public class Column : Entity
{
    public virtual string Name { get; set; }
    public virtual ColumnTypeValues Type { get; set; }

    public virtual IEnumerable<ColumnValue> ColumnValues { get; set; }

    public virtual IEnumerable<PriceList> PriceLists { get; set; }
}
