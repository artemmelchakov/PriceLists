using PriceLists.Data.Models;

namespace PriceLists.Data;

public interface IPriceListsRepository
{
    /// <summary> Получить сущность из БД. </summary>
    /// <param name="id"> Id сущности. </param>
    Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : BaseEntity;

    /// <summary> Получить сущность по указанной спецификации. </summary>
    /// <param name="specification"> Спецификация, описывающая поиск и преобразование сущности. </param>
    Task<TResult?> GetAsync<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : BaseEntity;

    /// <summary> Получить сущности <typeparamref name="TEntity"/> из БД. </summary>
    IQueryable<TEntity> Find<TEntity>() where TEntity : BaseEntity;

    /// <summary> Получить сущности по спецификации. </summary>
    /// <param name="specification">Спецификация.</param>
    IQueryable<TResult> Find<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : BaseEntity;

    /// <summary> Добавить сущность в контекст. </summary>
    /// <param name="entity"> Добавляемая сущность. </param>
    TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary>
    /// Добавить множество сущностей в контекст.
    /// </summary>
    /// <param name="entities"> Добавляемые сущности. </param>
    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

    /// <summary> Зарегистрировать изменения сущности в контексте. </summary>
    /// <param name="entity"> Изменяемая сущность. </param>
    void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary> Удалить сущность из контекста. </summary>
    /// <param name="id"> Id сущности. </param>
    Task DeleteAsync<TEntity>(uint id) where TEntity : BaseEntity;

    /// <summary> Асинхронно сохраняет все изменения, сделанные в этом контексте, в БД. </summary>
    /// <returns> Количество сущностей, записанных в БД. </returns>
    Task<int> SaveChangesAsync();
}