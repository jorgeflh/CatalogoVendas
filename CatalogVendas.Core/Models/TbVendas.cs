using System;
using System.Collections.Generic;

namespace CatalogoVendas.Core.Models
{
    public partial class TbVendas
    {
        public int IdVenda { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public decimal ValorVenda { get; set; }
        public DateTime? DataVenda { get; set; }
        public bool? EmitidoNf { get; set; }

        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbUsuario IdUsuarioCadastroNavigation { get; set; }
    }
}
