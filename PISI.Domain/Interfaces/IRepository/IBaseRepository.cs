using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Interfaces.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, int pageNumber = 0, int pageSize = 0);
        Task<T> Get(long id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            int pageNumber = 0, int pageSize = 0);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                    int pageNumber = 0, int pageSize = 0);

        int Count(Expression<Func<T, bool>> expression);

        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(long id);
        Task<int> CompleteAsync();
    }
}
