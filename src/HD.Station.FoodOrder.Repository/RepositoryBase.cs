using HD.Station.FoodOrder.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HD.Station.FoodOrder.Contracts.Services;

namespace HD.Station.FoodOrder.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
           RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) {
            RepositoryContext.Set<T>().Add(entity);
            //RepositoryContext.SaveChanges();

        }
        public void Update(T entity) {
            RepositoryContext.Set<T>().Update(entity);
            //RepositoryContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
           // RepositoryContext.SaveChanges();
        }

    }
}