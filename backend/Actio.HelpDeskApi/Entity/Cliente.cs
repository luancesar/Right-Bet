using Actio.HelpDeskApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Entity
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }        
        public string Ramo { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Skype { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public TipoCliente Tipo { get; set; }
        public string Observacao { get; set; }
        public bool Interno { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Produto> Produtos { get; set; }

    }
}
