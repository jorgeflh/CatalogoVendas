using CatalogoVendas.Core.Helpers;
using CatalogoVendas.Core.Interfaces.Repositories;
using CatalogoVendas.Core.Interfaces.Services;
using CatalogoVendas.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<bool> InsertUser(TbUsuario tbUsuario)
        {
            tbUsuario.Cpf = StringHelper.RemoveMask(tbUsuario.Cpf);
            tbUsuario.Rg = StringHelper.RemoveMask(tbUsuario.Rg);
            tbUsuario.Telefone = StringHelper.RemoveMask(tbUsuario.Telefone);

            return await usuarioRepository.InsertUsuario(tbUsuario);
        }

        public async Task<bool> UpdateUser(TbUsuario tbUsuario)
        {
            tbUsuario.Cpf = StringHelper.RemoveMask(tbUsuario.Cpf);
            tbUsuario.Rg = StringHelper.RemoveMask(tbUsuario.Rg);
            tbUsuario.Telefone = StringHelper.RemoveMask(tbUsuario.Telefone);

            return await usuarioRepository.UpdateUsuario(tbUsuario);
        }
    }
}
