using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Repositories
{
    public  interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> FindAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void PermanentDelete(T entity);
    } 
}
