using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Repository
{
    public interface IUsuarioRepository : IRepositoryHelpDeskContext<Usuario>
    {
        Task<bool> AutenticarUsuario(string userName, string password);
        Task<List<Usuario>> ObterUsuarios();
        Task<Usuario> GetByUserName(string userName);
        Task<Usuario> GetById(int userId);
    }
}
