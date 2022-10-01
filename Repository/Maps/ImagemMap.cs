using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class ImagemMap : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            builder.Property(x => x.Id)
              .HasColumnName("Id")
              .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                 .HasColumnName("nome")
                 .HasMaxLength(50);

            builder.Property(x => x.LinkImagem)
               .HasColumnName("ImagemUrl")
               .HasMaxLength(1000);

            // relacionamentos
            builder.Property(x => x.IdProduto)
                .HasColumnName("id_Produto")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Imagens)
                .HasForeignKey(x => x.IdProduto);

            builder.ToTable("ImagemProduto");

        }
    }
}
