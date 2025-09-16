using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClarityAndSuccess.Domain.Data;
using ClarityAndSuccess.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Infrastructure.Repository;

public class GenericRepository<T>(ClarityAndSuccessDBContext context, IConfigurationProvider mapperConfig) : IGenericRepository<T> where T : class
{
    protected readonly ClarityAndSuccessDBContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly IConfigurationProvider _mapperConfig = mapperConfig;

    public async Task<TResult?> GetFirstOrDefaultAsyncInclude<TResult>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _dbSet;

        if (include is not null)
            query = include(query);

        return await query
            .Where(filter)
            .Select(selector)   // projection
            .FirstOrDefaultAsync();
    }

    public async Task<T?> GetByIdAsync(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _dbSet;

        if (include is not null)
            query = include(query);

        return await query
            .Where(filter)
            .FirstOrDefaultAsync();
    }
    
    public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(
    Expression<Func<T, bool>> filter,
    IConfigurationProvider mapperConfig)
    {
        return await _dbSet
            .Where(filter)
            .ProjectTo<TResult>(mapperConfig)
            .FirstOrDefaultAsync();
    }

    // Add Async
    public virtual async Task AddAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Add Async
    public virtual async Task<T> AddEntityAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        if (entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities), "Entity list cannot be null or empty.");

        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

}
