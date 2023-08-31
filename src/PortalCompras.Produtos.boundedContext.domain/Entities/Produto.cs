using PortalCompras.Produtos.boundedContext.core.DomainObjects;

namespace PortalCompras.Produtos.boundedContext.domain.Entities
{
    /// <summary>
    /// Classe de dominio que representa um produto do nosso negocio
    /// </summary>
    public class Produto : Entity, IAggregateRoot
    {
        public string nome { get; private set; }
        public string descricao { get; private set; }
        public bool ativo { get; private set; }

        public decimal valor { get; private set; }

        public int estoque { get; private set; }
        public DateTime dataCadastro { get; private set; }

        public Produto (string nome, string descricao, bool ativo, decimal valor, int estoque, DateTime dataCadastro)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.ativo = ativo;
            this.valor = valor;
            this.estoque = estoque;
            this.dataCadastro = dataCadastro;
            Validar();
        }

        public void Validar ()
        {
            Validacoes.ValidarSeVazio(nome, "O campo nome do produto não pode esta vazio.");
            Validacoes.ValidarSeVazio(descricao, "O campo descrição do produto não pode esta vazio.");

            Validacoes.ValidarSeMenorQueMinimo(valor, 1, "O campo valor do produto não deve ser 0");
        }
        public void DebitarEstoque (int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            estoque -= quantidade;
        }

        public void ReporEstoque (int quantidade)
        {
            estoque += quantidade;
        }

        public bool PossuiEstoque (int quantidade)
        {
            return estoque >= quantidade;
        }
    }
}
