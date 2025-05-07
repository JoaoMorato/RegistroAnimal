using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace RepositoryUtil;
public abstract class Repository<D, T> : IRepository<T>
    where D : DbContext
    where T : class, TEntity
{
    private readonly D db;
    private readonly DbSet<T> table;

    public Repository(D db)
    {
        this.db = db;
        table = db.Set<T>();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        return (await table.AddAsync(entity)).Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        return table.Update(entity).Entity;
    }

    public virtual async Task RemoveAsync(T entity)
    {
        table.Remove(entity);
    }

    public virtual async Task RemoveAsync(IEnumerable<T> entity)
    {
        table.RemoveRange(entity);
    }

    public virtual async Task SaveChangesAsync()
    {
        var s = db.Database.CanConnect();
        await db.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return table.Where(e => true);
    }

    public IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> predicate)
    {
        return table.OrderBy(predicate);
    }

    public IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> predicate)
    {
        return table.OrderByDescending(predicate);
    }

    public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> predicate)
    {
        return table.Select(predicate);
    }

    public IQueryable<TResult> SelectMany<TResult>(Expression<Func<T, IEnumerable<TResult>>> predicate)
    {
        return table.SelectMany(predicate);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return table.Where(predicate);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await table.FirstOrDefaultAsync(predicate);
    }
    
    public async Task<T?> FirstOrDefaultAsync()
    {
        return await table.FirstOrDefaultAsync();
    }

    public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await table.FirstAsync(predicate);
    }

    public async Task<T> FirstAsync()
    {
        return await table.FirstAsync();
    }

    public async Task<T?> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await table.LastOrDefaultAsync(predicate);
    }
    
    public async Task<T?> LastOrDefaultAsync()
    {
        return await table.LastOrDefaultAsync();
    }

    public async Task<T> LastAsync(Expression<Func<T, bool>> predicate)
    {
        return await table.LastAsync(predicate);
    }
    
    public async Task<T> LastAsync()
    {
        return await table.LastAsync();
    }

    public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return table.FirstOrDefault(predicate);
    }

    public T? FirstOrDefault()
    {
        return table.FirstOrDefault();
    }

    public T First(Expression<Func<T, bool>> predicate)
    {
        return table.First(predicate);
    }

    public T First()
    {
        return table.First();
    }

    public T? LastOrDefault(Expression<Func<T, bool>> predicate)
    {
        return table.FirstOrDefault(predicate);
    }

    public T? LastOrDefault()
    {
        return table.FirstOrDefault();
    }

    public T Last(Expression<Func<T, bool>> predicate)
    {
        return table.Last(predicate);
    }

    public T Last()
    {
        return table.Last();
    }
}
