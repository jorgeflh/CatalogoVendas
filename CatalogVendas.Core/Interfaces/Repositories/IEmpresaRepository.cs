using CatalogVendas.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogVendas.Core.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> GetEmpresas();
        Task<Empresa> GetEmpresaById(int id);
        void InsertEmpresa(Empresa empresa);
        void DeleteEmpresa(int id);
        void UpdateEmpresa(Empresa empresa);
        void Save();
    }
}
