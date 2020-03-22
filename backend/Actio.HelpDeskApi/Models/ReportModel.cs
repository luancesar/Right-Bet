using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Models
{
    public class ReportModel
    {
        public decimal BancaInicial { get; set; }
        public decimal BancaAtual { get; set; }
        public int Entradas { get; set; }
        public decimal PorcentagemGreen { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal Parcial { get; set; }

    }
}
