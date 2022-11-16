using Domain.Entities.Usuario;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeVendida { get; private set; }

        public Guid IdCategoria { get; private set; }
        public virtual CategoriaProduto Categoria { get; private set; }

        public virtual List<ImagemProduto> Imagens { get; private set; }
        
        public virtual List<Cliente> Clientes { get; private set; }
        
        public void AdicionarCategoriaId(Guid id)
        {
            IdCategoria = id;
        }

        public void AdicionarImagem(ImagemProduto imagem)
        {
            Imagens.Add(imagem);
        }
    }
}
