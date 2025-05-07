using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Util.DI;

namespace RepositoryUtil;
public interface IRepository<T> where T : class, TEntity
{
    Task<T> AddAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveAsync(IEnumerable<T> entity);
    Task<T> UpdateAsync(T entity);
    Task SaveChangesAsync();
    IQueryable<T> GetAll();
    IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> predicate);
    IQueryable<TResult> SelectMany<TResult>(Expression<Func<T, IEnumerable<TResult>>> predicate);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> predicate);
    IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync();
    Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
    Task<T> FirstAsync();
    Task<T?> LastOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<T?> LastOrDefaultAsync();
    Task<T> LastAsync(Expression<Func<T, bool>> predicate);
    Task<T> LastAsync();

    T? FirstOrDefault(Expression<Func<T, bool>> predicate);
    T? FirstOrDefault();
    T First(Expression<Func<T, bool>> predicate);
    T First();
    T? LastOrDefault(Expression<Func<T, bool>> predicate);
    T? LastOrDefault();
    T Last(Expression<Func<T, bool>> predicate);
    T Last();
}
