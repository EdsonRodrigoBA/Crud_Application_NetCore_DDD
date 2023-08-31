using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalCompras.Produtos.boundedContext.Application.Services;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using PortalCompras.Produtos.boundedContext.ProdutosWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Testes
{
    public class ProdutoControllerTestes
    {
        private  IProdutoServices _produtoServices;
        private ProdutosController _produtosController;
        IValidator<ProdutoViewModel> _validator;
        public ProdutoControllerTestes()
        {
            _produtoServices = new ProdutoServicesFake();
            _validator = new ProdutoValidator();
            _produtosController = new ProdutosController(_produtoServices, _validator);
        }


        [Fact]
        public void GetProdutos_RetornaOkResult()
        {
            // Act
            var okResult = _produtosController.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetProdutos_RetornaTodosItens_OkResult()
        {
            // Act
            var okResult = _produtosController.Get(50,1).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ProdutoViewModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void AdicionarProduto_Retorna_CreatResult()
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
            // Act
            var CreatedResult = _produtosController.Post(produtoAdd).Result as CreatedResult;
            // Assert
            Assert.IsType<CreatedResult>(CreatedResult);
        }
    }
}
