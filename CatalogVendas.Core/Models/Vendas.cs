using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogVendas.Core.Models
{
    public class Vendas
    {
        public int IdVenda { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public decimal ValorVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public bool EmitidoNF { get; set; }
    }
}
