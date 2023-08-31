using FluentValidation;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.Validators
{
    /// <summary>
    /// Classe que define regras de validação das propriedades na criação ou atualizaçãoo de um produto
    /// </summary>
    public class ProdutoValidator : AbstractValidator<ProdutoViewModel>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.nome).NotEqual("string")
                .NotEmpty()
                .NotNull().WithMessage("Informe o nome do produto.");

            RuleFor(c => c.descricao).NotEqual("string")
            .NotEmpty().NotNull().WithMessage("Informe a descrição produto.");

            RuleFor(c => c.valor).GreaterThan(0).WithMessage("Informe o valor do produto");
            RuleFor(c => c.estoque).GreaterThan(0).WithMessage("Informe a quantidade de estoque do produto");



        }
    }
}
