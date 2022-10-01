namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; }
        public int Quantidade { get; }
        public string Descricao { get; }
        public decimal Preco { get; }

        public Guid IdCategoria { get; }
        public virtual CategoriaProduto Categoria { get; }

        public virtual List<ImagemProduto> Imagens { get; }
    }
}
