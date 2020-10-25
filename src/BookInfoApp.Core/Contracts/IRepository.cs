using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookInfoApp.Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookInfoApp.Core.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<EntityEntry<T>> Update(T entity);
        Task<EntityEntry<T>> Delete(T entity);
        void Delete(List<T> entities);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPageAsync(int numPage, int pageSize);
    }

    public interface IRepository<T, TId> : IRepository<T>
        where T : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        Task<T> GetByIdAsync(TId id);
    }
}
