using CatalogoVendas.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<TbEmpresa>> GetEmpresas();
        Task<TbEmpresa> GetEmpresaById(int id);
        void InsertEmpresa(TbEmpresa empresa);
        void DeleteEmpresa(int id);
        void UpdateEmpresa(TbEmpresa empresa);
        void Save();
    }
}
