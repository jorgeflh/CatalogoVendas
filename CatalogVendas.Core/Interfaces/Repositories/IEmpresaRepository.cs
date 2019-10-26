using CatalogoVendas.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<TbEmpresa>> GetEmpresas();
        Task<TbEmpresa> GetEmpresaById(int id);
        Task<bool> InsertEmpresa(TbEmpresa empresa);
        Task<bool> DeleteEmpresa(int id);
        Task<bool> UpdateEmpresa(TbEmpresa empresa);
    }
}
