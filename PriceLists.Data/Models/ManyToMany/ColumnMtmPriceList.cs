namespace PriceLists.Data.Models.ManyToMany;

public class ColumnMtmPriceList : BaseEntity
{
    public virtual uint ColumnId { get; set; }
    public virtual Column Column { get; set; } = null!;

    public virtual uint PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; } = null!;
}
