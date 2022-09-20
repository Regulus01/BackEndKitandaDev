namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public Guid IdCategoria { get; set; }
        public virtual CategoriaProduto Categoria { get; set; }

        public virtual List<ImagemProduto> Imagens { get; set; }
    }
}
