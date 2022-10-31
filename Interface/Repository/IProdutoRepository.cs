using Domain.Data.ViewModels.Criacao;
using ProductAPI.Data.ViewModels;

namespace Interface.Repository
{
    public interface IProdutoRepository
    {
        Task CriarProduto(ProdutoViewModel viewModel, string categoria);
        Task<IEnumerable<ProdutoGridViewModel>> GetAll();
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorCategoria(string nomeDaCategoria);
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorPagina(int pagina);
        Task<IEnumerable<ProdutoGridViewModel>> ObterMaisVendidos();
        Task<IEnumerable<ProdutoGridViewModel>> ObterProdutoPorNome(string nomeProduto);
    }
}
