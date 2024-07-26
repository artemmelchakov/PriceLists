using PriceLists.Data;
using PriceLists.Data.Models;

namespace PriceLists.Api.Specifications;

public class EntitiesByIdsSpec<TEntity> : ISpecification<TEntity, TEntity> where TEntity : Entity
{
    private readonly IEnumerable<uint> _ids;
    public EntitiesByIdsSpec(IEnumerable<uint> ids) => _ids = ids;
    public IQueryable<TEntity> AppendQuery(IQueryable<TEntity> entities) => entities.Where(e => _ids.Contains(e.Id));
}