using Aira.Core.Repository.Interface;
using Aira.Persistence.Aira;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aira.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AiraContext _context;
        protected DbSet<T> table;
        public BaseRepository(AiraContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetById(Guid id)
        {
            return await table.FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
        }
        public async Task Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(Guid id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(predicate);
        }
    }
}
