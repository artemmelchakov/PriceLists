using Microsoft.EntityFrameworkCore;
using PriceLists.Data.Models;

namespace PriceLists.Data;

public class PriceListsRepository : IPriceListsRepository
{
    private readonly PriceListsContext _context;

    public PriceListsRepository(PriceListsContext context) => _context = context;

    public async Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : BaseEntity => await _context.Set<TEntity>().FindAsync(id);

    public async Task<TResult?> GetAsync<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : BaseEntity =>
        await specification.AppendQuery(_context.Set<TEntity>()).FirstOrDefaultAsync();

    public IQueryable<TEntity> Find<TEntity>() where TEntity : BaseEntity => _context.Set<TEntity>();

    public IQueryable<TResult> Find<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : BaseEntity => 
        specification.AppendQuery(_context.Set<TEntity>());

    public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _ = await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity => 
        await _context.Set<TEntity>().AddRangeAsync(entities);

    public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity => _context.Set<TEntity>().Update(entity);

    public async Task DeleteAsync<TEntity>(uint id) where TEntity : BaseEntity
    {
        var entity = await GetAsync<TEntity>(id);
        if (entity is not null) _ = _context.Set<TEntity>().Remove(entity);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
