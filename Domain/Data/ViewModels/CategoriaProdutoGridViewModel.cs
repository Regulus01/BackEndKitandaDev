namespace ProductAPI.Data.ViewModels
{
    public class CategoriaProdutoGridViewModel
    {
        public string Nome { get; set; }
        public virtual List<ProdutoGridViewModel> Produtos { get; set; }
    }
}
