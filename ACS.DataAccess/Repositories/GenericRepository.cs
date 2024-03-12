using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACS.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private DbSet<T> dbSet = null;
        protected readonly IUserProvider _userProvider;
        public GenericRepository(
            DataContext context
            ,IUserProvider userProvider)
        {
            _context = context;
            dbSet = _context.Set<T>();
            _userProvider = userProvider;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

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
                return await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public void Insert(T entity)
        {
            //entity.Id ??= Guid.NewGuid();
            if (entity.Id == null)
                entity.Id = Guid.NewGuid();
            if (entity.CreatedById == null)
                entity.CreatedById = _userProvider.GetCurrentUserId();
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            entity.LastUpdatedById =  _userProvider.GetCurrentUserId();
            entity.LastUpdatedOn = DateTime.Now;
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.DeletedById = _userProvider.GetCurrentUserId();
            entity.IsDeleted = true;
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void PermanentDelete (T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

    }
}
