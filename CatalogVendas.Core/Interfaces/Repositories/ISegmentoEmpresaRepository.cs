using CatalogoVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogVendas.Core.Interfaces.Repositories
{
    interface ISegmentoEmpresaRepository
    {
        Task<List<TbSegmentoEmpresa>> GetSegmentosEmpresa();
        Task<TbSegmentoEmpresa> GetSegmentoEmpresaById(int id);
        void InsertSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa);
        void DeleteSegmentoEmpresa(int id);
        void UpdateSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa);
        void Save();
    }
}
