using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogVendas.Core.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
