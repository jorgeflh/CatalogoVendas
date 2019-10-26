using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoVendas.Core.Models
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbSegmentoEmpresa = new HashSet<TbSegmentoEmpresa>();
            TbVendas = new HashSet<TbVendas>();
        }

        [Display(Name = "ID Empresa")]
        public int IdEmpresa { get; set; }
        [Display(Name = "ID Usuário")]
        public int IdUsuarioCadastro { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "CNPJ")]
        [RegularExpression(@"[\d]{2}.[\d]{3}.[\d]{3}/[\d]{4}-[\d]{2}", ErrorMessage = "CNPJ incorreto")]
        public string Cnpj { get; set; }
        [Display(Name = "Endereço")]
        [MaxLength(255, ErrorMessage = "Endereço muito grande para o cadastro")]
        public string Endereco { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name ="Cadastrado por")]
        public virtual TbUsuario IdUsuarioCadastroNavigation { get; set; }
        public virtual ICollection<TbSegmentoEmpresa> TbSegmentoEmpresa { get; set; }
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
