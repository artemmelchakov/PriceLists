using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Data.Models;

namespace PriceLists.Api.Specifications.PriceListSpecs;

public class PriceListWithIncludedSpec : ISpecification<PriceList, PriceList>
{
    private readonly uint _id;
    public PriceListWithIncludedSpec(uint id) => _id = id;
    public IQueryable<PriceList> AppendQuery(IQueryable<PriceList> entities) => 
        entities.Where(e => e.Id == _id).Take(1).Include(e => e.Columns).Include(e => e.Products).Include(e => e.ColumnValues);
}
