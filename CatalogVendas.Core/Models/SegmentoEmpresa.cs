using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogVendas.Core.Models
{
    public class SegmentoEmpresa
    {
        public int IdSegmentoEmpresa { get; set; }
        public int IdEmpresa { get; set; }
        public string DesSegmento { get; set; }
        public bool Ativo { get; set; }
    }
}
