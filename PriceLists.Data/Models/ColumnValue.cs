namespace PriceLists.Data.Models;

public class ColumnValue : Entity
{
    public virtual string Value { get; set; } = null!;

    public virtual uint ColumnId { get; set; }
    public virtual Column Column { get; set; } = null!;

    public virtual uint ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}