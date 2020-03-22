using Actio.HelpDeskApi.Context;
using Actio.HelpDeskApi.Entity;
using Actio.HelpDeskApi.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Repository
{
    public class BetRepository :  RepositoryHelpDeskContext<Bet>, IBetRepository
    {
        public BetRepository(HelpDeskContext context) : base(context)
        {
        }

        public async Task<List<Bet>> GetBets()
        {
            return await _context.Bet.ToListAsync();
        }

        public async Task<Bet> GetById(int id)
        {
            return await _context.Bet.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
