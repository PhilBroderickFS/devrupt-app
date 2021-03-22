using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevRupt.App.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _applicationDbContext;
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await _applicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _applicationDbContext.Set<T>().Update(entity);
        }
    }
}
