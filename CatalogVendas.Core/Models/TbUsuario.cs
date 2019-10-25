using System;
using System.Collections.Generic;

namespace CatalogoVendas.Core.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbEmpresa = new HashSet<TbEmpresa>();
            TbVendas = new HashSet<TbVendas>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public string DesLogin { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<TbEmpresa> TbEmpresa { get; set; }
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
