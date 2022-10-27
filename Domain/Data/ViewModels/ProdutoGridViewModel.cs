namespace ProductAPI.Data.ViewModels
{
    public class ProdutoGridViewModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeVendida { get; set; }

        public Guid IdCategoria { get; set; }
        public string CategoriaNome { get; set; }

        public virtual List<ImagemProdutoGridViewModel> Imagens { get; set; }
    }
}
