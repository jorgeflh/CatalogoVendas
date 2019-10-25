using Microsoft.EntityFrameworkCore;
using CatalogoVendas.Core.Models;
using CatalogoVendas.Infra.Interfaces.Context;

namespace CatalogoVendas.Infra.Context
{
    public partial class CatalogoVendasContext : DbContext, ICatalogoVendasContext
    {
        public CatalogoVendasContext()
        {
        }

        public CatalogoVendasContext(DbContextOptions<CatalogoVendasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbSegmentoEmpresa> TbSegmentoEmpresa { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }
        public virtual DbSet<TbVendas> TbVendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CatalogoVendas;User Id=sa;Password=**servertest//;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__tb_Empre__5EF4033EB8C23764");

                entity.ToTable("tb_Empresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioCadastroNavigation)
                    .WithMany(p => p.TbEmpresa)
                    .HasForeignKey(d => d.IdUsuarioCadastro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_Empres__IdUsu__25869641");
            });

            modelBuilder.Entity<TbSegmentoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdSegmento)
                    .HasName("PK__tb_Segme__1A8C88F7DDF89289");

                entity.ToTable("tb_SegmentoEmpresa");

                entity.Property(e => e.DesSegmento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbSegmentoEmpresa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_Segmen__Ativo__286302EC");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__tb_Usuar__5B65BF9749D1D1EE");

                entity.ToTable("tb_Usuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DesLogin)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbVendas>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PK__tb_Venda__BC1DC6A928B19A30");

                entity.ToTable("tb_Vendas");

                entity.Property(e => e.DataVenda).HasColumnType("datetime");

                entity.Property(e => e.EmitidoNf).HasColumnName("EmitidoNF");

                entity.Property(e => e.ValorVenda).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbVendas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_Vendas__IdEmp__2B3F6F97");

                entity.HasOne(d => d.IdUsuarioCadastroNavigation)
                    .WithMany(p => p.TbVendas)
                    .HasForeignKey(d => d.IdUsuarioCadastro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_Vendas__IdUsu__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
