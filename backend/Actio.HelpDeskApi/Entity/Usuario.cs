using System.Collections.Generic;
using System.Linq;

namespace Actio.HelpDeskApi.Entity
{
    public class Usuario
    {
        public Usuario(string login)
        {
            Login = login;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public decimal BancaInicial { get; set; }  
        public decimal BancaAtual { get; set; }  
        public decimal PorcentagemFaturamento { get; set; }


        public void AtualizarBancaAtual(decimal bet)
        {
            this.BancaAtual += bet;
            this.PorcentagemFaturamento = (this.BancaAtual - this.BancaInicial) / this.BancaInicial * 100;

        }

        public void RecalculateValues(List<Bet> bets)
        {
            this.BancaAtual = this.BancaInicial + bets.Sum(b => b.Lucro);
            this.PorcentagemFaturamento = (this.BancaAtual - this.BancaInicial) / this.BancaInicial * 100;

        }


    }
}
