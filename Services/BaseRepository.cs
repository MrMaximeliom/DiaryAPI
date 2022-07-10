using DiaryAPI.Conists;
using DiaryAPI.Services;
using DiaryAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiaryAPI.Services


{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T>? GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T? Find(Expression<Func<T, bool>> match, string[] includes = null!)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);

                }
            }

            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);

                }
            }
            return query.Where(match).ToList();

        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip)
        {
            return _context.Set<T>().Where(match).Skip(skip).Take(take).ToList();
        }


        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null!, string OrderByDirection = OrderBy.ASCENDING)
        {
            IQueryable<T> query = _context.Set<T>().Where(match);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (orderBy != null)
            {
                if (OrderByDirection == OrderBy.ASCENDING)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            return query.ToList();


        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
           
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entitties)
        {
            _context.Set<T>().AddRange(entitties);
           
            return entitties;
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);

        }

        public int Count()
        {
            return _context.Set<T>().Count();

        }
        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }
    }
}
