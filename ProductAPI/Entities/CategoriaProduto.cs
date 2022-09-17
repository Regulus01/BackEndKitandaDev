namespace ProductAPI.Entities
{
    public class CategoriaProduto : BaseEntity
    {
        public string Nome { get; set; }

        public virtual List<Produto> Produtos { get; set; } 

    }
}
