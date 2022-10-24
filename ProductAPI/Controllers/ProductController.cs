using Domain.Data.ViewModels.Criacao;
using Interface.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data.ViewModels;

namespace ProductAPI.Controllers
{
    [Route("Produto")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProductController(IProdutoRepository produtoRepository)
        {
            _repository = produtoRepository ?? throw new
                ArgumentException(nameof(produtoRepository));
        }
        
        /// <summary>
        ///     EndPoint authorize para criar novos produtos
        /// </summary>
        ///  <remarks>
        ///       End point usado para criar produto utilizando um produtoviewmodel e uma categoria(existente)
        ///  </remarks>
        /// <returns>
        ///     Sem retorno
        /// </returns>
        /// <response code="200"> Produto inserido no banco </response>
        /// <response code="401"> Não autorizado </response>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProdutoViewModel>> CriarProduto([FromBody] ProdutoViewModel? viewModel, string categoria)
        {
            if (viewModel == null)
                return BadRequest();

            await _repository.CriarProduto(viewModel, categoria);

            return Ok();
        }
        
        /// <summary>
        ///     EndPoint para exibir todos os produtos no banco
        /// </summary>
        ///  <remarks>
        ///       End point sem parametro que obtem todos os produtos do banco.
        ///  </remarks>
        /// <returns>
        ///     Retorna produtos Criados
        /// </returns>
        /// <response code="200"> Retornar os produtos </response>
        /// <response code="404"> Não há produtos no banco </response>
        /// <response code="400"> Erro na requisiçào </response>
        [HttpGet]
        [Route("ObterProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> GetAll()
        {
            var produtos = await _repository.GetAll();
            if (produtos.Any())
            {
                return Ok(produtos);
            }

            return NotFound();
        }

        /// <summary>
        ///     EndPoint para exibir uma paginação com 5 produtos.
        /// </summary>
        ///  <remarks>
        ///       End point que recebe uma pagina de produtos por parametro.
        ///  </remarks>
        /// <returns>
        ///     Retorna uma paginação com 5 produtos
        /// </returns>
        /// <response code="200"> Retornar os produtos paginados </response>
        /// <response code="404"> Não há produtos no banco </response>
        /// <response code="400"> Erro na requisiçào </response>
        [HttpGet("Pagina/{pagina}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> ProdutosPorPagina(int pagina = 1)
        {
            var produtos = await _repository.ProdutosPorPagina(pagina);
            
            if (produtos.Any())
            {
                return Ok(produtos);
            }

            return NotFound();
        }

        /// <summary>
        ///     EndPoint para exibir produtos por categoria
        /// </summary>
        ///  <remarks>
        ///       End point que recebe uma nome de categoria como parametro
        ///  </remarks>
        /// <returns>
        ///     Retorna produtos com as categorias correspondentes
        /// </returns>
        /// <response code="200"> Retornar os produtos </response>
        /// <response code="404"> Não há produtos no banco </response>
        /// <response code="400"> Erro na requisiçào </response>
        [HttpGet("{nomeDaCategoria}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> ProdutosPorCategoria(string nomeDaCategoria)
        {
            var produtos = await _repository.ProdutosPorCategoria(nomeDaCategoria);
            if (produtos.Any())
            {
                return Ok(produtos);
            }

            return NotFound();
        }
    }
}
