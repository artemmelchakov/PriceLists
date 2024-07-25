using PriceLists.Data;
using PriceLists.Data.Models;

namespace PriceLists.Api.Specifications.ColumnSpecs;

public class ColumnsByIdsAndPriceListIdSpec : ISpecification<Column, Column>
{
    private readonly IEnumerable<uint> _columnIds;
    private readonly uint _priceListId;
    public ColumnsByIdsAndPriceListIdSpec(IEnumerable<uint> columnIds, uint priceListId)
    {
        _columnIds = columnIds;
        _priceListId = priceListId;
    }
    public IQueryable<Column> AppendQuery(IQueryable<Column> entities) => 
        entities.Where(e => _columnIds.Contains(e.Id) && e.PriceLists.Select(pl => pl.Id).Contains(_priceListId));
}
