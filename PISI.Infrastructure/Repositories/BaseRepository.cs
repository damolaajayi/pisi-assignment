using Microsoft.EntityFrameworkCore;
using PISI.Domain.Entities.Common;
using PISI.Domain.Interfaces.IRepository;
using PISI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PISIDbContext _context;

        public BaseRepository(PISIDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Attach<T>(entity));
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            _context.Update(entity);
        }

        public Task<T> Get(long id, CancellationToken cancellationToken)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, int pageNumber = 0, int pageSize = 0)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderby != null)
            {
                var ordered = orderby(query);
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = ordered.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                    return await query.ToListAsync(cancellationToken);
                }
                else
                {
                    return await ordered.ToListAsync(cancellationToken);
                }
            }
            else
            {
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }

                return await query.ToListAsync(cancellationToken);
            }
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, int pageNumber = 0, int pageSize = 0)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderby != null)
            {
                var ordered = orderby(query);
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = ordered.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                    return await query.ToListAsync();
                }
                else
                {
                    return await ordered.ToListAsync();
                }
            }
            else
            {
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }

                return await query.ToListAsync();
            }
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, int pageNumber = 0, int pageSize = 0)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderby != null)
            {
                var ordered = orderby(query);
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = ordered.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }
            }
            else
            {
                if (pageNumber != 0 && pageSize != 0)
                {
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }
            }

            return query;
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            query = query.Where(expression);
            return query.Count();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            query = query.Where(expression);
            return await query.CountAsync();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
