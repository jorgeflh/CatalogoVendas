using CatalogoVendas.Core.Models;
using CatalogoVendas.Infra.Context;
using CatalogVendas.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVendas.Infra.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CatalogoVendasContext context;

        public UsuarioRepository(CatalogoVendasContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                var tbUsuario = await context.TbUsuario.FindAsync(id);
                context.TbUsuario.Remove(tbUsuario);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TbUsuario> GetUsuarioById(int id)
        {
            var tbUsuario = await context.TbUsuario.FirstOrDefaultAsync(m => m.IdUsuario == id);

            if (tbUsuario == null)
            {
                return null;
            }

            return tbUsuario;
        }

        public async Task<List<TbUsuario>> GetUsuarios()
        {
            return await context.TbUsuario.ToListAsync();
        }

        public async Task<bool> InsertUsuario(TbUsuario usuario)
        {
            try
            {
                context.Add(usuario);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUsuario(TbUsuario usuario)
        {
            try
            {
                context.Update(usuario);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
