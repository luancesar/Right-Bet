using Actio.HelpDeskApi.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Utils
{
    public abstract class RepositoryHelpDeskContext<TDomain> where TDomain : class
    {
        protected readonly HelpDeskContext _context;

        public RepositoryHelpDeskContext(HelpDeskContext context)
        {
            _context = context;
        }

        public virtual void Add(TDomain entity)
        {
            _context.Set<TDomain>().Add(entity);
        }

        public virtual async Task AddAsync(TDomain entity)
        {
            await _context.Set<TDomain>().AddAsync(entity);
        }

        public virtual void Delete(TDomain entity)
        {
            _context.Set<TDomain>().Remove(entity);
        }

        public virtual async Task DeleteAsync(TDomain entity)
        {
            await Task.FromResult(_context.Set<TDomain>().Remove(entity));
        }

        public virtual void Update(TDomain entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TDomain>().Update(entity);
        }

        public async Task UpdateAsync(TDomain entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(_context.Set<TDomain>().Update(entity));
        }
    }
}
