namespace Domain.Entities
{
    public class ImagemProduto : BaseEntity
    {
        public string Nome { get; }
        public string LinkImagem { get; }

        public Guid IdProduto { get; }
        public virtual Produto Produto { get; }

    }
}
