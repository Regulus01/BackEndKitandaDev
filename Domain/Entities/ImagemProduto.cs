namespace Domain.Entities
{
    public class ImagemProduto : BaseEntity
    {
        public string Nome { get; private set;  }
        public string LinkImagem { get; private set; }

        public Guid IdProduto { get; private set;  }
        public virtual Produto Produto { get; private set; }
        
        public void CriarImagemProdutoSemFoto()
        {
            Nome = "Principal";
            LinkImagem = "https://www.inovegas.com.br/site/wp-content/uploads/2017/08/sem-foto.jpg";
        }

        public void InformeIdProduto(Guid idProduto)
        {
            IdProduto = idProduto;
        }

        public void InformeProduto(Produto produto)
        {
            Produto = produto;
        }

    }
}
