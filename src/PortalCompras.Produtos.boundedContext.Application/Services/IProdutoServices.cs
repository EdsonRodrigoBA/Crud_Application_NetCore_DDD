using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.Services
{
    /// <summary>
    /// Interface que orquestra nossa camada Repository de infraestrutura que faz comunicação com o banco de dados. 
    /// </summary>
    public interface IProdutoServices : IDisposable
    {
        Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel);
        Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoViewModel);
        Task<bool> Excluir(Guid Id);
        Task<ProdutoViewModel> BuscarPorId(Guid Id);
        Task<dynamic> ListarTodos(int offset = 1, int limite = 50);




        Task<ProdutoViewModel> AdicionarSqlLite(ProdutoViewModel produtoViewModel);
        Task<ProdutoViewModel> AtualizarSqlLite(ProdutoViewModel produtoViewModel);
        Task<bool> ExcluirSqlLite(Guid Id);
        Task<ProdutoViewModel> BuscarPorIdSqlLite(Guid Id);
        Task<dynamic> ListarTodosSqlLite(int offset = 1, int limite = 50);

    }
}
