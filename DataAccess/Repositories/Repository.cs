using BusinessLogic.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal SportShopDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(SportShopDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task <IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            return dbSet.Find(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
