using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CatalogoVendas.Core.Interfaces.Repositories;
using CatalogoVendas.Core.Models;
using CatalogoVendas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVendas.Infra.Repositories
{
    public class VendasRepository : IVendasRepository
    {
        private readonly CatalogoVendasContext context;

        public VendasRepository(CatalogoVendasContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteVenda(int id)
        {
            try
            {
                var tbVendas = await context.TbVendas.FindAsync(id);
                context.TbVendas.Remove(tbVendas);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TbVendas> GetVendaById(int id)
        {
            return await context.TbVendas
                .Include(t => t.IdEmpresaNavigation)
                .Include(t => t.IdUsuarioCadastroNavigation)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
        }

        public async Task<List<TbVendas>> GetVendas()
        {
            var catalogoVendasContext = context.TbVendas.Include(t => t.IdEmpresaNavigation).Include(t => t.IdUsuarioCadastroNavigation);
            return await catalogoVendasContext.ToListAsync();
        }

        public async Task<bool> InsertVenda(TbVendas vendas)
        {
            try
            {
                context.Add(vendas);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateVenda(TbVendas vendas)
        {
            try
            {
                context.Update(vendas);
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
