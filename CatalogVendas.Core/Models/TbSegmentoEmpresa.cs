using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoVendas.Core.Models
{
    public partial class TbSegmentoEmpresa
    {
        [Required]
        [Display(Name = "Segmento")]
        public int IdSegmento { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }
        [Required]
        [Display(Name = "Seguimento")]
        [MaxLength(255)]
        public string DesSegmento { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool? Ativo { get; set; }

        [Display(Name = "Empresa")]
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
    }
}
