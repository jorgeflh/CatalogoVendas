using CatalogVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogVendas.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        void InsertUsuario(Usuario usuario);
        void DeleteUsuario(int id);
        void UpdateUsuario(Usuario usuario);
        void Save();
    }
}
