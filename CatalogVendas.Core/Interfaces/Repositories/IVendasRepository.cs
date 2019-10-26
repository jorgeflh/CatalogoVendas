using CatalogoVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Interfaces.Repositories
{
    public interface IVendasRepository
    {
        Task<List<TbVendas>> GetVendas();
        Task<TbVendas> GetVendaById(int id);
        Task<bool> InsertVenda(TbVendas vendas);
        Task<bool> DeleteVenda(int id);
        Task<bool> UpdateVenda(TbVendas vendas);
    }
}
