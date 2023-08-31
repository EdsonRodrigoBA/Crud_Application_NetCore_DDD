namespace PortalCompras.Produtos.boundedContext.core.DomainObjects
{
    /// <summary>
    /// Exceção personalizada pra que nossas entidade de dominio possam se auto validar.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException()
        {

        }

        public DomainException(string message) : base(message)
        {

        }
        public DomainException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
