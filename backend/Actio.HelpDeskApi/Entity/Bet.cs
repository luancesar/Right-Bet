using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Entity
{
    public class Bet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Stake { get; set; }
        public decimal ODD { get; set; }
        public bool Green { get; set; }
        public decimal Lucro { get; set; }
        public decimal SaldoAtual { get; set; }
        public decimal Porcentagem { get; set; }

    }
}
