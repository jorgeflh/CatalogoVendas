using CatalogVendas.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogVendas.Core.Interfaces.Repositories
{
    public interface IVendasRepository
    {
        Task<List<Vendas>> GetVendas();
        Task<Vendas> GetVendaById(int id);
        void InsertVenda(Vendas vendas);
        void DeleteVenda(int id);
        void UpdateVenda(Usuario usuario);
        void Save();
    }
}
