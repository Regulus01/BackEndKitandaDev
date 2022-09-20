﻿namespace Domain.Entities
{
    public class ImagemProduto : BaseEntity
    {
        public string Nome { get; private set; }
        public string LinkImagem { get; private set; }

        public Guid IdProduto { get; private set; }
        public virtual Produto Produto { get; private set; }

    }
}
