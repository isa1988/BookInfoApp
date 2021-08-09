using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookInfo_Core.Entities;
using BookInfo_Core.Helper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookInfo_Core.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);
        T Create(T entity);
        EntityEntry<T> Update(T entity);
        EntityEntry<T> Delete(T entity);
        Task SaveAsync();
        void Save();

        Task<List<T>> GetAllAsync(ResolveOptions resolveOptions = null);

        Task<List<T>> GetPageAsync(int numPage, int pageSize, ResolveOptions resolveOptions = null);
    }

    public interface IRepository<T, TId> : IRepository<T>
        where T : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        Task<T> GetByIdAsync(TId id, ResolveOptions resolveOptions = null);
    }
}
