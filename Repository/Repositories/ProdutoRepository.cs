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
        protected const int TamanhoPagina = 5;
        protected readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

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

        public async Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorPagina(int pagina)
        {

            List<Produto> produtos = await _context.Produtos
                                            .Include(x => x.Categoria)
                                            .Include(y => y.Imagens)
                                            .Skip(TamanhoPagina * (pagina - 1))
                                            .Take(TamanhoPagina)
                                            .OrderBy(x => x.Quantidade)
                                            .ToListAsync();


            return _mapper.Map<List<ProdutoGridViewModel>>(produtos);

        }

        public async Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorCategoria(string nomeDaCategoria)
        {
            List<Produto> produtos = await _context.Produtos
                                            .Include(x => x.Categoria)
                                            .Include(y => y.Imagens)
                                            .OrderBy(x => x.Quantidade)
                                            .ToListAsync();

            var produtosCategoria = produtos.Where(x =>
            RemoverAcentos(x.Categoria.Nome.ToUpper()) == RemoverAcentos(nomeDaCategoria.ToUpper()));

            return _mapper.Map<List<ProdutoGridViewModel>>(produtosCategoria);
        }

        private string RemoverAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }
    }
}
