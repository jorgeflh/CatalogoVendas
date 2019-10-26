using CatalogoVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<TbUsuario>> GetUsuarios();
        Task<TbUsuario> GetUsuarioById(int id);
        Task<bool> InsertUsuario(TbUsuario usuario);
        Task<bool> DeleteUsuario(int id);
        Task<bool> UpdateUsuario(TbUsuario usuario);
    }
}
