using PortalCompras.Produtos.boundedContext.Application.Services;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Testes
{
    internal class ProdutoServicesFake : IProdutoServices
    {
        private readonly List<ProdutoViewModel> _produtoViewModels;
        public ProdutoServicesFake()
        {
            _produtoViewModels = new List<ProdutoViewModel>()
            {
                new ProdutoViewModel()
                {
                    Id = Guid.NewGuid(),
                    nome = "Produto Teste 1",
                    descricao = "Produto Teste 1 descricao",
                    ativo = true,
                    valor = 10,
                    estoque = 100,
                    dataCadastro = DateTime.Now
                },

                new ProdutoViewModel()
                {
                    Id = Guid.NewGuid(),
                    nome = "Produto Teste 2",
                    descricao = "Produto Teste 2 descricao",
                    ativo = true,
                    valor = 50,
                    estoque = 12,
                    dataCadastro = DateTime.Now
                },
                new ProdutoViewModel()
                {
                    Id = Guid.NewGuid(),
                    nome = "Produto Teste 3",
                    descricao = "Produto Teste 3 descricao",
                    ativo = true,
                    valor = 25,
                    estoque = 14,
                    dataCadastro = DateTime.Now
                }

            };
        }
        public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produtoAdd = new ProdutoViewModel
            {
                Id = Guid.NewGuid(),
                nome = "Produto Teste 4",
                descricao = "Produto Teste 3 descricao",
                ativo = true,
                valor = 25,
                estoque = 14,
                dataCadastro = DateTime.Now
            };
            _produtoViewModels.Add(produtoAdd);

            return produtoAdd;
        }

        public Task<ProdutoViewModel> AdicionarSqlLite(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> AtualizarSqlLite(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoViewModel> BuscarPorId(Guid Id)
        {
            return _produtoViewModels.FirstOrDefault(x => x.Id == Id);
        }

        public Task<ProdutoViewModel> BuscarPorIdSqlLite(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Excluir(Guid Id)
        {
            var produto = _produtoViewModels.FirstOrDefault(x => x.Id == Id);
            if(produto == null)
            {
                return false;
            }

            _produtoViewModels.Remove(produto);
            return true;
        }

        public Task<bool> ExcluirSqlLite(Guid Id)
        {
            throw new NotImplementedException();
        }

        public  async Task<dynamic> ListarTodos(int offset = 1, int limite = 50)
        {
            var produtos =  _produtoViewModels.Skip(limite * (offset - 1))
                .Take(limite).ToList();

            var quantidadeProduto = _produtoViewModels.Count();
            var quantidadePaginas = (int)Math.Ceiling((decimal)quantidadeProduto / limite);
            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }

            return new { produtos, quantidadePaginas, pagina = $"{offset.ToString()}-{quantidadePaginas}" };

        }

        public Task<dynamic> ListarTodosSqlLite(int offset = 1, int limite = 50)
        {
            throw new NotImplementedException();
        }
    }
}
