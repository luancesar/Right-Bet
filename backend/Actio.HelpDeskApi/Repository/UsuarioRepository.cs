using Actio.HelpDeskApi.Context;
using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Utils;
using CryptSharp;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Repository
{
    public class UsuarioRepository : RepositoryHelpDeskContext<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HelpDeskContext context) : base(context)
        {

        }

        public async Task<bool> AutenticarUsuario(string login, string password)
        {
            return await _context.Usuario.AnyAsync(p => p.Login.ToLower() == login.ToLower() && Crypter.CheckPassword(p.Senha, password));
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }
        public async Task<Usuario> GetByUserName(string userName)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Login == userName.ToLower());
        }
        public async Task<Usuario> GetById(int userId)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
