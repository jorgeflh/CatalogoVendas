using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoVendas.Core.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbEmpresa = new HashSet<TbEmpresa>();
            TbVendas = new HashSet<TbVendas>();
        }

        [Required]
        [Display(Name = "ID")]
        public int IdUsuario { get; set; }
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required]
        [Display(Name = "RG")]
        [MaxLength(14)]
        public string Rg { get; set; }
        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Required]
        [Display(Name = "Login")]
        [MaxLength(11)]
        public string DesLogin { get; set; }
        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string Senha { get; set; }

        [Display(Name = "Empresa")]
        public virtual ICollection<TbEmpresa> TbEmpresa { get; set; }
        [Display(Name = "Vendas")]
        public virtual ICollection<TbVendas> TbVendas { get; set; }
    }
}
