﻿using GTS.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GTS.Infrastructure.Persistence;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<T?> FindAsync(Expression<Func<T, bool>> criteria, params string[]? includes)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.SingleOrDefaultAsync(criteria);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<int> CountAsync()
        => await _context.Set<T>().CountAsync();

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        => await _context.Set<T>().CountAsync(criteria);

    public async Task<IEnumerable<T>> PaginateAsync(int pageNumber = 1, int pageSize = 10, params string[]? includes)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return await Task.FromResult(entity);
    }
}
