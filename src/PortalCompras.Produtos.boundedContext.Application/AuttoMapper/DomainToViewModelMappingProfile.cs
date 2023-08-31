using AutoMapper;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using PortalCompras.Produtos.boundedContext.domain.Entities;

namespace PortalCompras.Produtos.boundedContext.Application.AuttoMapper
{
    /// <summary>
    /// Esta classe faz o mapeamento de todos objetos de dominio pra os objetos de tranferencia 
    /// que serão exibidos pelos clientes
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();

        }

    }
}
