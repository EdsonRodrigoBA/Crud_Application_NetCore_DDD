namespace PortalCompras.Produtos.boundedContext.core.Data
{
    /// <summary>
    /// 
    /// Classe responsavel por acompanha as alterações das entidades de negócio durante uma transação sendo também responsável pelo gerenciamento dos problemas de concorrência que podem ocorrer oriundos dessa transação.
    /// </summary>
    public interface IUnitOfWork
    {
        Task<bool> Commit ();
    }
}
