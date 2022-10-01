namespace Domain.Entities
{
    public class CategoriaProduto : BaseEntity
    {
        public string Nome { get; }

        public virtual List<Produto> Produtos { get; } 

    }
}
