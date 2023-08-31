using AutoMapper;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using PortalCompras.Produtos.boundedContext.domain.Intefaces;
using PortalCompras.Produtos.boundedContext.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.Services
{
    /// <summary>
    /// Classe que orquestra nossa camada Repository de infraestrutura que faz comunicação com o banco de dados.
    /// aqui podemos concentrar nossas regras de negocio.
    /// </summary>
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;

        public ProdutoServices(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }



        public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Adicionar(produto);

            await _produtoRepository.unitOfWork.Commit();

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Atualizar(produto);

            await _produtoRepository.unitOfWork.Commit();

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> BuscarPorId(Guid Id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.BuscarPorId(Id));
    
            return produto;
        }


        public async Task<bool> Excluir(Guid Id)
        {
            var produto = await _produtoRepository.BuscarPorId(Id);
            if(produto == null)
            {
                return false;
            }
            var retorno = await _produtoRepository.Excluir(Id);
            await _produtoRepository.unitOfWork.Commit();

            return retorno;

        }

        public async Task<dynamic> ListarTodos(int offset = 1, int limite = 50)
        {
            if(limite <=0 || limite > 50)
            {
                limite = 50;
            }
            if (offset <= 0 )
            {
                limite = 1;
            }
            var produtos =  _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ListarTodos(offset, limite));
   
            var quantidadeProduto = await _produtoRepository.CountProdutos();
            var quantidadePaginas = (int)Math.Ceiling((decimal)quantidadeProduto / limite);
            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }
            return new { produtos , quantidadePaginas, pagina= $"{offset.ToString()}-{quantidadePaginas}" };
        }

        #region Manipular dados no SqlLite
        public async Task<ProdutoViewModel> AdicionarSqlLite(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.AdicionarSqlLite(produto);

            await _produtoRepository.unitOfWork.Commit();

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> AtualizarSqlLite(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.AtualizarSqlLite(produto);

            await _produtoRepository.unitOfWork.Commit();

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> BuscarPorIdSqlLite(Guid Id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.BuscarPorIdSqlLite(Id));

            return produto;
        }


        public async Task<bool> ExcluirSqlLite(Guid Id)
        {
            var produto = await _produtoRepository.BuscarPorIdSqlLite(Id);
            if (produto == null)
            {
                return false;
            }
            var retorno = await _produtoRepository.ExcluirSqlLite(Id);
            await _produtoRepository.unitOfWork.Commit();

            return retorno;

        }

        public async Task<dynamic> ListarTodosSqlLite(int offset = 1, int limite = 50)
        {
            if (limite <= 0 || limite > 50)
            {
                limite = 50;
            }
            if (offset <= 0)
            {
                limite = 1;
            }
            var produtos = _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ListarTodosSqlLite(offset, limite));

            var quantidadeProduto = await _produtoRepository.CountProdutosSqlLite();
            var quantidadePaginas = (int)Math.Ceiling((decimal)quantidadeProduto / limite);
            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }
            return new { produtos, quantidadePaginas, pagina = $"{offset.ToString()}-{quantidadePaginas}" };
        }

        #endregion

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
