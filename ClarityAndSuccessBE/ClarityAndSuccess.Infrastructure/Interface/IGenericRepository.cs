using System.Linq.Expressions;
using AutoMapper;

namespace ClarityAndSuccess.Infrastructure.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<IEnumerable<TResult>> GetAllSelectAsync<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<TResult?> GetFirstOrDefaultSelectAsync<TResult>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<TResult?> GetFirstOrDefaultProjectedAsync<TResult>(
        Expression<Func<T, bool>> filter,
        IConfigurationProvider mapperConfig);

    Task AddAsync(T entity);

    Task<T> AddEntityAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
}
