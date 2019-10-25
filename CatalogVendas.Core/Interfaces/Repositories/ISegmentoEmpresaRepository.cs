using CatalogVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogVendas.Core.Interfaces.Repositories
{
    interface ISegmentoEmpresaRepository
    {
        Task<List<SegmentoEmpresa>> GetSegmentosEmpresa();
        Task<SegmentoEmpresa> GetSegmentoEmpresaById(int id);
        void InsertSegmentoEmpresa(SegmentoEmpresa segmentoEmpresa);
        void DeleteSegmentoEmpresa(int id);
        void UpdateSegmentoEmpresa(SegmentoEmpresa segmentoEmpresa);
        void Save();
    }
}
