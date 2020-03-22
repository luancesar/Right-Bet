using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Repository
{
    public interface IBetRepository : IRepositoryHelpDeskContext<Bet>
    {
        Task<List<Bet>> GetBets();
        Task<Bet> GetById(int userId);
    }
}
