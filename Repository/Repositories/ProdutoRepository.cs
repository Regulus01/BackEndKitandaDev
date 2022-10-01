using AutoMapper;
using Domain.Data.ViewModels.Criacao;
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
        private IMapper _mapper;

        public ProdutoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CriarProduto(ProdutoViewModel viewModel, string categoria)
        {
            var categoriaExiste = _context.CategoriaProdutos
                .FirstOrDefault(x => x.Nome.ToUpper() == categoria.ToUpper());

            if (categoriaExiste == null) 
                throw new NullReferenceException("Categoria não existe");

            var produto = _mapper.Map<Produto>(viewModel);
            produto.AdicionarCategoriaId(categoriaExiste.Id);
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProdutoGridViewModel>> GetAll()
        {

            var produtos = await _context.Produtos
                                            .Include(x => x.Categoria)
                                            .Include(y => y.Imagens)
                                            .OrderBy(x => x.Quantidade)
                                            .ToListAsync();


            return _mapper.Map<List<ProdutoGridViewModel>>(produtos);

        }

        public async Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorPagina(int pagina)
        {

            var produtos = await _context.Produtos
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
            var produtos = await _context.Produtos
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
            var comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            var semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (var i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }
    }
}
