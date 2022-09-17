using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities;

namespace ProductAPI.Maps
{
    public class ProdutoMap : BaseMap<Produto>
    {
        public ProdutoMap(string tableNome) : base("tb_produto")
        {
        }

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnName("preco")
                .HasPrecision(17, 2)
                .IsRequired();

            // Relacionamentos

            builder.Property(x => x.IdCategoria)
                .HasColumnName("id_categoria")
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoria);

           
        }
    }
}
