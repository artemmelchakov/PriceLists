using Microsoft.Extensions.DependencyInjection;
using PriceLists.Data.Models;

namespace PriceLists.Data;

public class AppRepository : IRepository
{
    private readonly AppContext _context;
    public AppRepository(IServiceProvider serviceProvider) => _context = serviceProvider.GetRequiredService<AppContext>();

    /// <inheritdoc/>
    public async Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : BaseEntity => await _context.Set<TEntity>().FindAsync(id);

    /// <inheritdoc/>
    public TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _ = _context.Set<TEntity>().Add(entity);
        return entity;
    }

    /// <inheritdoc/>
    public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity => _context.Set<TEntity>().Update(entity);

    /// <inheritdoc/>
    public async Task DeleteAsync<TEntity>(uint id) where TEntity : BaseEntity
    {
        var entity = await GetAsync<TEntity>(id);
        if (entity is not null) _ = _context.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc/>
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    #region Disposing
    private bool _disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
