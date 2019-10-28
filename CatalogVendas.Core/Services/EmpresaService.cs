using CatalogoVendas.Core.Helpers;
using CatalogoVendas.Core.Interfaces.Repositories;
using CatalogoVendas.Core.Interfaces.Services;
using CatalogoVendas.Core.Models;
using System.Threading.Tasks;

namespace CatalogoVendas.Core.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        public async Task<bool> InsertCompany(TbEmpresa tbEmpresa)
        {
            tbEmpresa.Cnpj = StringHelper.RemoveMask(tbEmpresa.Cnpj);
            tbEmpresa.Telefone = StringHelper.RemoveMask(tbEmpresa.Telefone);
            return await empresaRepository.InsertEmpresa(tbEmpresa);
        }

        public async Task<bool> UpdateCompany(TbEmpresa tbEmpresa)
        {
            tbEmpresa.Cnpj = StringHelper.RemoveMask(tbEmpresa.Cnpj);
            tbEmpresa.Telefone = StringHelper.RemoveMask(tbEmpresa.Telefone);
            return await empresaRepository.UpdateEmpresa(tbEmpresa);
        }
    }
}
