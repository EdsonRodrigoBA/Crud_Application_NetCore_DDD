using PortalCompras.Produtos.boundedContext.core.Data;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System.Linq.Expressions;

namespace PortalCompras.Produtos.boundedContext.domain.Intefaces
{
    /// <summary>
    /// Classe que implementa operações pra gerenciamento do produto
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task<int> CountProdutos();
        Task<Produto> AdicionarSqlLite (Produto objetc);
        Task<Produto> AtualizarSqlLite (Produto objetc);

        Task<bool> ExcluirSqlLite (Guid Id);
        Task<Produto> BuscarPorIdSqlLite (Guid Id);
        Task<List<Produto>> ListarTodosSqlLite (int offset = 1, int limite = 50);

        public Task<int> CountProdutosSqlLite ();

    }
}
