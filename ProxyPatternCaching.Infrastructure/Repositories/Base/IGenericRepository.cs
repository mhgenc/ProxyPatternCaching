using ProxyPatternCaching.Domain.Base;

namespace ProxyPatternCaching.Infrastructure.Repositories.Base;

public interface IGenericRepository<T> where T : class, IEntity, new()
{
    Task<T?> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
}