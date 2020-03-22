using Actio.HelpDeskApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    public interface IBetService
    {
        Task<bool> Bet(BetModel model);
        Task<List<BetModel>> GetBets();
        Task<bool> Delete(int id);
        Task<byte[]> DownloadFile(string endereco);


    }
}
