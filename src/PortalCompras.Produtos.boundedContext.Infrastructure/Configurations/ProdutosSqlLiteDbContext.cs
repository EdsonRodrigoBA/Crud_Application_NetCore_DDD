using Microsoft.EntityFrameworkCore;
using PortalCompras.Produtos.boundedContext.core.Data;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Infrastructure.Configurations
{
    /// <summary>
    /// Essa classe de contexto administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados.
    /// </summary>
    public class ProdutosSqlLiteDbContext : DbContext, IUnitOfWork
    {
        public ProdutosSqlLiteDbContext()
        {

        }
        public ProdutosSqlLiteDbContext(DbContextOptions<ProdutosSqlLiteDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(250");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutosSqlLiteDbContext).Assembly);

        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
