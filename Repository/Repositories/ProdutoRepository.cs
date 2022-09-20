using AutoMapper;
using Domain.Entities;
using Interface.Repository;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data.ViewModels;
using Repository.Common;

namespace Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProdutoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoGridViewModel>> GetAll()
        {

            List<Produto> produtos = await _context.Produtos
                                            .Include(x => x.Categoria)
                                            .Include(y => y.Imagens)
                                            .OrderBy(x => x.Quantidade)
                                            .ToListAsync();

            return _mapper.Map<List<ProdutoGridViewModel>>(produtos);

        }
    }
}
