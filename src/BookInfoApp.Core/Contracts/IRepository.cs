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
        T Create(T entity);
        EntityEntry<T> Update(T entity);
        EntityEntry<T> Delete(T entity);
        Task SaveAsync();
        void Save();

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
