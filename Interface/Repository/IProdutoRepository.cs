using Domain.Data.ViewModels.Criacao;
using KitandaAPI.Data.ViewModels;

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
        Task<IEnumerable<ProdutoGridViewModel>> ObterProdutoPorId(Guid id);
    }
}
