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
        void InsertVenda(TbVendas vendas);
        void DeleteVenda(int id);
        void UpdateVenda(TbVendas vendas);
        void Save();
    }
}
