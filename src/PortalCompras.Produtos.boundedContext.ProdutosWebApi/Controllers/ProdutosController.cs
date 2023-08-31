using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalCompras.Produtos.boundedContext.Application.Services;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using PortalCompras.Produtos.boundedContext.Application.ViewModels;

namespace PortalCompras.Produtos.boundedContext.ProdutosWebApi.Controllers
{

    /// <summary>
    /// LEsta classe foi desenvolvida pra testar a Api Usando a Base de dados Mysql
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>

    [Route("api/v1/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutoServices _produtoServices;
        IValidator<ProdutoViewModel> _validator;


        public ProdutosController(IProdutoServices produtoServices, IValidator<ProdutoViewModel> validator)
        {
            _produtoServices = produtoServices;
            _validator = validator;
        }


        /// <summary>
        /// Lista os produtos paginados, cada pagina tem no maximo 50 registros
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>os produtos paginados</returns>
        /// <response code="200">Returna os os produtos cadastros paginados</response>       
        /// <response code="204">Retorna caso não encontre produtos cadastrados</response>

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<dynamic>))]
        [ProducesResponseType((500))]
        [ProducesResponseType((204))]

        public async Task<IActionResult> Get(int limite =50, int offset = 1)
        {

            var produtos = await _produtoServices.ListarTodos(offset, limite);
   
            return Ok(produtos);
        }

        /// <summary>
        /// Retorna um produto com base no seu Id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Um produto cadastro</returns>
        /// <response code="200">Returna um produto cadastrado</response>
        /// <response code="204">Returna um produto nao localizado pelo Id</response>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ProdutoViewModel))]
        [ProducesResponseType((500))]
        [ProducesResponseType((204))]
        public async Task<IActionResult> Get(Guid id)
        {

            var produtos = await _produtoServices.BuscarPorId(id);
            if(produtos == null)
            {
                return NoContent();
            }
            return Ok(produtos);
        }


        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///     
        ///      "nome": "nome do produto",
        ///      "descricao": "descrição do produto",
        ///      "ativo": true,
        ///      "valor": 1,
        ///     "estoque": 1
        ///   }     
        ///</remarks>
        /// <returns>Um produto cadastro</returns>
        /// <response code="201">Retorna o produto cadastrado</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(ProdutoViewModel))]
        [ProducesResponseType((400), Type = typeof(List<MessageValidatorResult>))]
        [ProducesResponseType((500))]
        [Produces("application/json")]

        public async Task<IActionResult> Post(ProdutoViewModel model)
        {
            var validation = await _validator.ValidateAsync(model);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }
            model.Id = Guid.Empty;
            var produto = await _produtoServices.Adicionar(model);
            return StatusCode(StatusCodes.Status201Created, produto);
        }


        /// <summary>
        /// Atualiza um  produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///      "nome": "nome do produto",
        ///      "descricao": "descrição do produto",
        ///      "ativo": true,
        ///      "valor": 1,
        ///     "estoque": 1
        ///   }     
        ///</remarks>
        /// <returns>Um produto Atualizado</returns>
        /// <response code="201">Retorna o produto com dados atualizados</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        [HttpPut]
        [ProducesResponseType((201), Type = typeof(ProdutoViewModel))]
        [ProducesResponseType((400), Type = typeof(List<MessageValidatorResult>))]
        [ProducesResponseType((500))]

        public async Task<IActionResult> Putt(ProdutoViewModel model)
        {
            var validation = await _validator.ValidateAsync(model);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }

            var produto = await _produtoServices.Atualizar(model);
            return StatusCode(StatusCodes.Status201Created, produto);
        }

        /// <summary>
        /// Excluir um  produto
        /// </summary>
        /// <remarks>   
        ///</remarks>
        /// <returns>No Content</returns>
        /// <response code="204"></response>
        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((500))]

        public async Task<IActionResult> Delete(Guid id)
        {

            var produto = await _produtoServices.Excluir(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
