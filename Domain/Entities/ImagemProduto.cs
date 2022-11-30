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
            LinkImagem = "https://www.bstest.com.br/wp-content/uploads/2019/09/produto-sem-imagem-1000x1000.jpg";
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
