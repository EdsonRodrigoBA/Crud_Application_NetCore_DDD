using ExpectedObjects;
using PortalCompras.Produtos.boundedContext.core.DomainObjects;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Testes
{
    public class ProdutoDomainTestes
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarException()
        {
            var ex = Assert.Throws<DomainException>(() => new Produto(
                String.Empty, "Descrição", false, 100, 10, DateTime.Now)
                );
            Assert.Equal("O campo nome do produto não pode esta vazio.", ex.Message);

             ex = Assert.Throws<DomainException>(() => new Produto(
            "Nome do Produto", String.Empty, false, 100, 10, DateTime.Now)
            );
            Assert.Equal("O campo nome do produto não pode esta vazio.", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "nome", "Descrição", false, 0, 10, DateTime.Now)
                );
            Assert.Equal("O campo descrição do produto não pode esta vazio.", ex.Message);
        }

        [Fact]
        public void Criacao_Produto_Valido()
        {
            var produtoEsperado = new
            {

                nome = "nome produto Teste",
                descricao = "descricao produto Teste",
                ativo = true,
                valor = 100,
                estoque = 10,
                dataCadastro = DateTime.Now

            };
            var produto = new Produto(produtoEsperado.nome, produtoEsperado.descricao, produtoEsperado.ativo, produtoEsperado.valor,
                    produtoEsperado.estoque, produtoEsperado.dataCadastro);
            produtoEsperado.ToExpectedObject().ShouldMatch(produto);
        }

        [Fact]
        public void Valida_Se_Produtos_Iguais()
        {
            var produto1 = new
            {

                nome = "nome produto Teste",
                descricao = "descricao produto Teste",
                ativo = true,
                valor = 100,
                estoque = 10,
                dataCadastro = DateTime.Now

            };

            var produto2 = new
            {

                nome = "nome produto Teste",
                descricao = "descricao produto Teste",
                ativo = true,
                valor = 100,
                estoque = 10,
                dataCadastro = DateTime.Now

            };
            Assert.Equal(produto1.Equals(produto2), false); 
        }
    }
}
