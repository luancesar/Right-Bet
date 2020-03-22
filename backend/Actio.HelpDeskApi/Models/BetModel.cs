using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Models
{
    public class BetModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stake { get; set; }
        public string Odd { get; set; }
        public bool Green { get; set; }
        public string Lucro { get; set; }
        public string SaldoAtual { get; set; }
        public string Porcentagem { get; set; }
    }
}
