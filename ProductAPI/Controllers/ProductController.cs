using Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data.ViewModels;
using System.Collections;

namespace ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProductController(IProdutoRepository produtoRepository)
        {
            _repository = produtoRepository ?? throw new
                ArgumentException(nameof(produtoRepository));
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
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> GetAll()
        {
            var produtos = await _repository.GetAll();
            if (produtos != null)
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
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> ProdutosPorCategoria(string nomeDaCategoria)
        {
            var produtos = await _repository.ProdutosPorCategoria(nomeDaCategoria);
            if (produtos != null)
            {
                return Ok(produtos);
            }

            return NotFound();
        }
    }
}
