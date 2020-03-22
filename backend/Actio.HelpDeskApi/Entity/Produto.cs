using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Entity
{
    public class Produto
    {
        public Produto()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }        
    }
}
