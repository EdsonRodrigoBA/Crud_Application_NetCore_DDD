using AutoMapper;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.AuttoMapper
{
    /// <summary>
    /// Esta classe faz o mapeamento dos campos  que vem de nossa view pra nosso objetos de dominio
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<ProdutoViewModel, Produto>()
            .ConstructUsing(p =>
        new Produto(p.nome, p.descricao, p.ativo,
            p.valor, p.estoque, p.dataCadastro
            ));
        }
    }
}
