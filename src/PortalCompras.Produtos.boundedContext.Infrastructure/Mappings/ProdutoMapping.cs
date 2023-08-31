using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Infrastructure.Mappings
{

    
    /// <summary>
    /// Classe dresponsavel por modelar as propriedades do nosso objeto de dominio no banco de dados
    /// </summary>
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.valor)
                .IsRequired()
                .HasColumnType("numeric(18,2");


           
        }
    }
}
