using Actio.HelpDeskApi.Models;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    public interface IUsuarioService
    {
        Task<bool> AutenticarUsuario(string userName, string password);
        Task<bool> RegistrarUsuario(UserModel userName);
        Task<UserModel[]> ObterUsuarios();
        Task<bool> DeleteUser(int userId);
        Task<ReportModel> GetReportModel();


    }
}
