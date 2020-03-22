using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Utils
{
    public interface IRepositoryHelpDeskContext<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
    }
}
