using System;
using System.Collections.Generic;

namespace CatalogoVendas.Core.Models
{
    public partial class TbSegmentoEmpresa
    {
        public int IdSegmento { get; set; }
        public int IdEmpresa { get; set; }
        public string DesSegmento { get; set; }
        public bool? Ativo { get; set; }

        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
    }
}
