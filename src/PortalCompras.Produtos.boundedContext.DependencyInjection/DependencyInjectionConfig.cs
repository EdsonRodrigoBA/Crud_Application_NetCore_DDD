using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PortalCompras.Produtos.boundedContext.Application.AuttoMapper;
using PortalCompras.Produtos.boundedContext.Application.Services;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using PortalCompras.Produtos.boundedContext.domain.Intefaces;
using PortalCompras.Produtos.boundedContext.Infrastructure.Configurations;
using PortalCompras.Produtos.boundedContext.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.DependencyInjection
{
    /// <summary>
    /// Classe dresponsavel por concentrar o registro de todas dependencia dos projetos WebApp
    /// </summary>
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProdutosMysqlDbContext>();
            services.AddScoped<ProdutosSqlLiteDbContext>();

            services.AddScoped<IProdutoServices, ProdutoServices>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddFluentValidation(typeof(ProdutoValidator));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            return services;
        }



    }
}
