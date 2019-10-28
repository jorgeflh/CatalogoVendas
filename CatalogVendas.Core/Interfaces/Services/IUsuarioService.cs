using System.Threading.Tasks;
using CatalogoVendas.Core.Models;

namespace CatalogoVendas.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> InsertUser(TbUsuario tbUsuario);
        Task<bool> UpdateUser(TbUsuario tbUsuario);
    }
}