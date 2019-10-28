using System.Threading.Tasks;
using CatalogoVendas.Core.Models;

namespace CatalogoVendas.Core.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task<bool> InsertCompany(TbEmpresa tbEmpresa);
        Task<bool> UpdateCompany(TbEmpresa tbEmpresa);
    }
}