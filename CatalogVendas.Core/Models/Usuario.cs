using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogVendas.Core.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string DesLogin { get; set; }
        public string Senha { get; set; }
    }
}
