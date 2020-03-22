using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public string BancaInicial{ get; set; }
    }
}