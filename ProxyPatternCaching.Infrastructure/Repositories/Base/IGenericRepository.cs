using System.Linq.Expressions;
using FleetManagement.Domain.Base;

namespace FleetManagement.Application.Repositories;

public interface IGenericRepository<T> where T : class, IEntity, new()
{
    Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<bool> Exist(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(string id, T entity);
    Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
}