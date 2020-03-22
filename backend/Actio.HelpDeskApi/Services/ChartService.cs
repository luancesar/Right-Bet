using Actio.HelpDeskApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Services
{
    public class ChartService : IChartService
    {
        private readonly IBetService _betService;


        public ChartService(IBetService betService)
        {
            _betService = betService;
        }

        public async Task<ChartModel> GetModel()
        {
            var bets = await _betService.GetBets();

            var betsDay = bets.Where(b => b.Date.Day == DateTime.Now.Day && b.Date.Month == DateTime.Now.Month && b.Date.Year == DateTime.Now.Year);

            var model = new ChartModel()
            {
                Odds = betsDay.Select(b => Convert.ToDecimal(b.Odd)).ToArray(),
                Bets = betsDay.Select(b => new BetChartModel(){ Faturamento = Convert.ToDecimal(b.Porcentagem), Green= b.Green }).ToArray()
            };

            return model;
        }

    }
}
