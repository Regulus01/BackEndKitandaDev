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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoGridViewModel>>> GetAll()
        {
            var produtos = await _repository.GetAll();
            return Ok(produtos);
        }
    }
}
