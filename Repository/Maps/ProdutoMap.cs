using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Id)
              .HasColumnName("Id")
              .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade")
                .HasMaxLength(50)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnName("preco")
                .HasPrecision(17, 2)
                .IsRequired();

            builder.Property(x => x.QuantidadeVendida)
                .HasColumnName("QuantidadeVendida")
                .IsRequired();

            // Relacionamentos

            builder.Property(x => x.IdCategoria)
                .HasColumnName("id_categoria")
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoria);

            builder.ToTable("Produto");
        }
    }
}
