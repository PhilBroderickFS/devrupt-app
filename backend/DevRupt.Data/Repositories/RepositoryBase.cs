using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevRupt.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepsoitoryBase<T> where T : class
    {
        protected ApplicationDbContext applicationDbContext;
        public RepositoryBase(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public void Create(T entity)
        {
            applicationDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            applicationDbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await applicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            applicationDbContext.Set<T>().Update(entity);
        }
    }
}
