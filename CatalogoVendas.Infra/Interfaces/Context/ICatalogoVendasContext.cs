using CatalogoVendas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVendas.Infra.Interfaces.Context
{
    public interface ICatalogoVendasContext
    {
        DbSet<TbEmpresa> TbEmpresa { get; set; }
        DbSet<TbSegmentoEmpresa> TbSegmentoEmpresa { get; set; }
        DbSet<TbUsuario> TbUsuario { get; set; }
        DbSet<TbVendas> TbVendas { get; set; }
    }
}