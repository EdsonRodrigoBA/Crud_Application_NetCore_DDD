namespace PortalCompras.Produtos.boundedContext.core.DomainObjects
{
    /// <summary>
    /// Uma raiz de agregação é responsável por gerenciar os objetos de domínio filhos e garantir que os dados serão sempre salvos em conjunto, sendo assim, o repositório terá acesso somente a raiz de agregação e não aos objetos filhos.
    /// </summary>
    public interface IAggregateRoot
    {
    }
}
