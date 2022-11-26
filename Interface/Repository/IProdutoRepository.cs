using Domain.Data.ViewModels.Criacao;
using KitandaAPI.Data.ViewModels;

namespace Interface.Repository
{
    public interface IProdutoRepository
    {
        Task CriarProduto(ProdutoViewModel viewModel);
        Task<IEnumerable<ProdutoGridViewModel>> GetAll();
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorCategoria(string nomeDaCategoria);
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorPagina(int pagina);
        Task<IEnumerable<ProdutoGridViewModel>> ObterMaisVendidos();
        Task<IEnumerable<ProdutoGridViewModel>> ObterProdutoPorNome(string nomeProduto);
        ProdutoGridViewModel ObterProdutoPorId(Guid id);
    }
}
