﻿using System.Linq.Expressions;

namespace Shltet.Repository.IRepo
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, object>>[]? includeProps = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);
        Task<T?> GetOneAsync(Expression<Func<T, object>>[]? includeProps = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);
        Task CreateAsync(T entity);
        void Edit(T entity);
        void Delete(T entity);
        Task CommitAsync();
    }

}
