using ProductAPI.Data.ViewModels;

namespace Interface.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoGridViewModel>> GetAll();
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorCategoria(string nomeDaCategoria);
        Task<IEnumerable<ProdutoGridViewModel>> ProdutosPorPagina(int pagina);
    }
}
