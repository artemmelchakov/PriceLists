using PriceLists.Data.Models;

namespace PriceLists.Data;

public interface IRepository : IDisposable
{
    /// <summary> Получить сущность из БД. </summary>
    /// <param name="id"> Id сущности. </param>
    Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : BaseEntity;

    /// <summary> Добавить сущность в контекст. </summary>
    /// <param name="entity"> Добавляемая сущность. </param>
    TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary> Зарегистрировать изменения сущности в контексте. </summary>
    /// <param name="entity"> Изменяемая сущность. </param>
    void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary> Удалить сущность из БД. </summary>
    /// <param name="id"> Id сущности. </param>
    Task DeleteAsync<TEntity>(uint id) where TEntity : BaseEntity;

    /// <summary> Асинхронно сохраняет все изменения, сделанные в этом контексте, в БД. </summary>
    /// <returns> Количество сущностей, записанных в БД. </returns>
    Task<int> SaveChangesAsync();
}