using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookInfoApp.DAL.Repositories
{

    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        public Repository(DbContextBookInfoApp context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }
        protected DbContextBookInfoApp context;
        protected DbSet<T> dbSet { get; set; }
        
        public virtual async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entries = await dbSet.ToListAsync();
            return entries;
        }

        public virtual async Task<List<T>> GetPageAsync(int pageNumber, int rowCount)
        {
            int startIndex = (pageNumber - 1) * rowCount;
            var entries = await dbSet
                .Skip(startIndex)
                .Take(rowCount)
                .ToListAsync();
            return entries;
        }
        public virtual EntityEntry<T> Update(T entity)
        {
            var entry = dbSet.Update(entity);
            return entry;
        }

        public virtual EntityEntry<T> Delete(T entity)
        {
            var entry = dbSet.Remove(entity);
            return entry;
        }

        public virtual async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }

    public class Repository<T, TId> : Repository<T>, IRepository<T, TId>
        where T : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        public Repository(DbContextBookInfoApp context)
            : base(context)
        {
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            var entry = await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return entry;
        }
    }
}
