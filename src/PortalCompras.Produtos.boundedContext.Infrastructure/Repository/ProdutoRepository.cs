using Microsoft.EntityFrameworkCore;
using PortalCompras.Produtos.boundedContext.core.Data;
using PortalCompras.Produtos.boundedContext.domain.Entities;
using PortalCompras.Produtos.boundedContext.domain.Intefaces;
using PortalCompras.Produtos.boundedContext.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Infrastructure.Repository
{
    /// <summary>
    /// Classe dresponsavel por realizar transações em nossa base de dados.
    /// </summary>
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutosMysqlDbContext _context;
        private readonly ProdutosSqlLiteDbContext _contextSqlLite;

        public ProdutoRepository(ProdutosMysqlDbContext context, ProdutosSqlLiteDbContext contextSqlLite)
        {
            _context = context;
            _contextSqlLite = contextSqlLite;
        }

        public IUnitOfWork unitOfWork => _context;

        public async Task<Produto> Adicionar(Produto objetc)
        {
            await _context.Produtos.AddAsync(objetc);
            return objetc;
        }

        public async Task<Produto> Atualizar(Produto objetc)
        {
             _context.Produtos.Update(objetc);
            return objetc;

        }

        public async Task<Produto> BuscarPorId(Guid Id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
        }


        public async Task<bool> Excluir(Guid Id)
        {
            var produto = await BuscarPorId(Id);

            _context.Produtos.Remove(produto);
            return true;
        }


        public async Task<List<Produto>> ListarTodos(int offset =1, int limite = 50)
        {
            return await _context.Produtos.AsNoTracking()
                .Skip(limite * (offset - 1))
                .Take(limite)
                . ToListAsync();
        }

        public async Task<int> CountProdutos()
        {
            return await _context.Produtos.CountAsync();
        }

        #region Rotinas pra manpular base SQLite
        public async Task<Produto> AdicionarSqlLite(Produto objetc)
        {
            await _contextSqlLite.Produtos.AddAsync(objetc);
            return objetc;
        }

        public async Task<Produto> AtualizarSqlLite(Produto objetc)
        {
            _contextSqlLite.Produtos.Update(objetc);
            return objetc;

        }

        public async Task<Produto> BuscarPorIdSqlLite(Guid Id)
        {
            return await _contextSqlLite.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);
        }


        public async Task<bool> ExcluirSqlLite(Guid Id)
        {
            var produto = await BuscarPorIdSqlLite(Id);

            _contextSqlLite.Produtos.Remove(produto);
            return true;
        }


        public async Task<List<Produto>> ListarTodosSqlLite(int offset = 1, int limite = 50)
        {
            return await _contextSqlLite.Produtos.AsNoTracking()
                .Skip(limite * (offset - 1))
                .Take(limite)
                .ToListAsync();
        }

        public async Task<int> CountProdutosSqlLite()
        {
            return await _contextSqlLite.Produtos.CountAsync();
        }
        #endregion
        public void Dispose()
        {
            _context?.Dispose();
        }

    
    }
}
