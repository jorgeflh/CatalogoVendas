using CatalogoVendas.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Interfaces.Repositories
{
    public interface ISegmentoEmpresaRepository
    {
        Task<List<TbSegmentoEmpresa>> GetSegmentosEmpresa();
        Task<TbSegmentoEmpresa> GetSegmentoEmpresaById(int id);
        Task<bool> InsertSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa);
        Task<bool> DeleteSegmentoEmpresa(int id);
        Task<bool> UpdateSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa);
    }
}
