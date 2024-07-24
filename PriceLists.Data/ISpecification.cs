using PriceLists.Data.Models;

namespace PriceLists.Data;

/// <summary>
/// Спецификация, описывающая поиск и преобразование сущностей из контекста.
/// </summary>
/// <typeparam name="TEntity"> Тип сущности. </typeparam>
/// <typeparam name="TResult"> Результирующий тип. </typeparam>
public interface ISpecification<TEntity, TResult> where TEntity : BaseEntity
{
    IQueryable<TResult> AppendQuery(IQueryable<TEntity> entities);
}
