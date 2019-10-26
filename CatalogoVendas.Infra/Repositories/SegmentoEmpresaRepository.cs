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
    public class SegmentoEmpresaRepository : ISegmentoEmpresaRepository
    {
        private readonly CatalogoVendasContext context;

        public SegmentoEmpresaRepository(CatalogoVendasContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteSegmentoEmpresa(int id)
        {
            try
            {
                var tbSegmentoEmpresa = await context.TbSegmentoEmpresa.FindAsync(id);
                context.TbSegmentoEmpresa.Remove(tbSegmentoEmpresa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TbSegmentoEmpresa> GetSegmentoEmpresaById(int id)
        {
            return await context.TbSegmentoEmpresa
                .Include(t => t.IdEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdSegmento == id);
        }

        public async Task<List<TbSegmentoEmpresa>> GetSegmentosEmpresa()
        {
            var catalogoVendasContext = context.TbSegmentoEmpresa.Include(t => t.IdEmpresaNavigation);
            return await catalogoVendasContext.ToListAsync();
        }

        public async Task<bool> InsertSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa)
        {
            try
            {
                context.Add(segmentoEmpresa);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSegmentoEmpresa(TbSegmentoEmpresa segmentoEmpresa)
        {
            try
            {
                context.Update(segmentoEmpresa);
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
