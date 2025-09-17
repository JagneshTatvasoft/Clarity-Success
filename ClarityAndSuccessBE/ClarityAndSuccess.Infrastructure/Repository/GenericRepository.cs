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

    // Get all
    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _dbSet;

        // Apply filter
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Apply include
        if (include != null)
        {
            query = include(query);
        }

        // Apply orderBy
        if (orderBy != null)
        {
            query = query.OrderBy(orderBy);
        }

        return await query.ToListAsync();
    }

    // GET all with select
    public async Task<IEnumerable<TResult>> GetAllSelectAsync<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null
        )
    {
        IQueryable<T> query = _dbSet;

        // Apply filter
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Apply include
        if (include != null)
        {
            query = include(query);
        }

        // Apply orderBy
        if (orderBy != null)
        {
            query = query.OrderBy(orderBy);
        }

        //Apply select
        return await query.Select(select).ToListAsync();
    }

    // Get First or Default 
    public async Task<T?> GetFirstOrDefaultAsync(
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

    // Get First or Default with select
    public async Task<TResult?> GetFirstOrDefaultSelectAsync<TResult>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _dbSet;

        if (orderBy != null)
            query = orderBy(query);

        if (include is not null)
            query = include(query);

        return await query
            .Where(filter)
            .Select(selector)
            .FirstOrDefaultAsync();
    }

    // Get First or Default with projection
    public async Task<TResult?> GetFirstOrDefaultProjectedAsync<TResult>(
    Expression<Func<T, bool>> filter,
    IConfigurationProvider _mapperConfig)
    {
        return await _dbSet
            .Where(filter)
            .ProjectTo<TResult>(_mapperConfig)
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

    // Update Async
    public virtual async Task UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }


}
