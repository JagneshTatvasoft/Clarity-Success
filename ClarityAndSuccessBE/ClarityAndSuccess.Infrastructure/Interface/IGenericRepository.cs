using System.Linq.Expressions;
using AutoMapper;

namespace ClarityAndSuccess.Infrastructure.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<TResult?> GetFirstOrDefaultAsync<TResult>(
    Expression<Func<T, bool>> filter,
    IConfigurationProvider mapperConfig);

    Task<TResult?> GetFirstOrDefaultAsyncInclude<TResult>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<T?> GetByIdAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task AddAsync(T entity);
    Task<T> AddEntityAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
}
