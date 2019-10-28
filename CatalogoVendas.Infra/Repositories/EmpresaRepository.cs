using CatalogoVendas.Core.Interfaces.Repositories;
using CatalogoVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoVendas.Infra.Context;

namespace CatalogoVendas.Infra.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly CatalogoVendasContext context;

        public EmpresaRepository(CatalogoVendasContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteEmpresa(int id)
        {
            try
            {
                var tbEmpresa = await context.TbEmpresa.FindAsync(id);
                context.TbEmpresa.Remove(tbEmpresa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TbEmpresa> GetEmpresaById(int id)
        {
            return await context.TbEmpresa
                .Include(t => t.IdUsuarioCadastroNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
        }

        public async Task<List<TbEmpresa>> GetEmpresas()
        {
            var catalogoVendasContext = context.TbEmpresa.Include(t => t.IdUsuarioCadastroNavigation);
            return await catalogoVendasContext.ToListAsync();
        }

        public async Task<bool> InsertEmpresa(TbEmpresa empresa)
        {
            try
            {
                context.Add(empresa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdateEmpresa(TbEmpresa empresa)
        {
            try
            {
                context.Update(empresa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
