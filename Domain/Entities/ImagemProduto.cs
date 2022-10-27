namespace Domain.Entities
{
    public class ImagemProduto : BaseEntity
    {
        public string Nome { get; private set;  }
        public string LinkImagem { get; private set; }

        public Guid IdProduto { get; private set;  }
        public virtual Produto Produto { get; }


        public ImagemProduto CriarImagemProdutoSemFoto(Guid idProduto)
        {
            ImagemProduto imagem = new ImagemProduto();
            imagem.Nome = "Capa";
            imagem.LinkImagem = "https://www.inovegas.com.br/site/wp-content/uploads/2017/08/sem-foto.jpg";
            imagem.IdProduto = idProduto;

            return imagem;
        }

    }
}
