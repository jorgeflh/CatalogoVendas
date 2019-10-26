using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoVendas.Core.Models
{
    public partial class TbVendas
    {
        [Required]
        [Display(Name = "ID Venda")]
        public int IdVenda { get; set; }
        [Required]
        [Display(Name = "ID Empresa")]
        public int IdEmpresa { get; set; }
        [Required]
        [Display(Name = "ID Usuário")]
        public int IdUsuarioCadastro { get; set; }
        [Required]
        [Display(Name = "Valor da Venda")]
        [DataType(DataType.Currency)]
        public decimal ValorVenda { get; set; }
        [Required]
        [Display(Name = "Data")]
        public DateTime? DataVenda { get; set; }
        [Required]
        [Display(Name = "Emitido NF?")]
        public bool? EmitidoNf { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        public virtual TbUsuario IdUsuarioCadastroNavigation { get; set; }
    }
}
