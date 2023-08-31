using PortalCompras.Produtos.boundedContext.core.DomainObjects;

namespace PortalCompras.Produtos.boundedContext.core.Data
{
    /// <summary>
    /// Repositorio Generico
    /// </summary>
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork unitOfWork { get; }
        Task<T> Adicionar (T objetc);
        Task<T> Atualizar (T objetc);
        Task<bool> Excluir (Guid Id);
        Task<T> BuscarPorId (Guid Id);
        Task<List<T>> ListarTodos (int offset = 1, int limite = 50);
    }
}
