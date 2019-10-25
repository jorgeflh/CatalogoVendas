using System;
using System.Collections.Generic;

namespace CatalogoVendas.Core.Models
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbSegmentoEmpresa = new HashSet<TbSegmentoEmpresa>();
            TbVendas = new HashSet<TbVendas>();
        }

        public int IdEmpresa { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual TbUsuario IdUsuarioCadastroNavigation { get; set; }
        public virtual ICollection<TbSegmentoEmpresa> TbSegmentoEmpresa { get; set; }
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
