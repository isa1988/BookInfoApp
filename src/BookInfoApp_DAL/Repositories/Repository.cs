using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_Core.Contracts;
using BookInfo_Core.Entities;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookInfo_DAL.Repositories
{

    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
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

        public virtual T Create(T entity)
        {
            var entry = dbSet.Add(entity);

            return entry.Entity;
        }

        public virtual async Task<List<T>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entries = await ResolveInclude(resolveOptions).ToListAsync();
            return entries;
        }

        public virtual async Task<List<T>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            int startIndex = (pageNumber - 1) * rowCount;
            var entries = await ResolveInclude(resolveOptions)
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

        public virtual void Save()
        {
            context.SaveChanges();
        }
        protected abstract IQueryable<T> ResolveInclude(ResolveOptions resolveOptions);
    }

    public abstract class Repository<T, TId> : Repository<T>, IRepository<T, TId>
        where T : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly bool isIdAutoIncrement;
        public Repository(DbContextBookInfoApp context, bool isIdAutoIncrement = false)
            : base(context)
        {
            this.isIdAutoIncrement = isIdAutoIncrement;
        }

        public virtual async Task<T> GetByIdAsync(TId id, ResolveOptions resolveOptions = null)
        {
            var entity = await ResolveInclude(resolveOptions).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                throw new NullReferenceException("Не найдено значение по идентификатору");
            return entity;
        }

        protected abstract TId GetNewId();

        public override async Task<T> CreateAsync(T entity)
        {
            if (!isIdAutoIncrement)
            {
                entity.Id = GetId(GetNewId());
            }

            return await base.CreateAsync(entity);
        }

        private TId GetId(TId value)
        {
            if (dbSet.Any(p => p.Id.Equals(value)))
            {

                value = GetNewId();
                return GetId(value);
            }

            return value;
        }
    }
}

