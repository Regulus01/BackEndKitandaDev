using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class ImagemMap : BaseMap<ImagemProduto>
    {
        public ImagemMap(string tableNome) : base(tableNome)
        {
        }

        public override void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome)
                 .HasColumnName("nome")
                 .HasMaxLength(50);

            builder.Property(x => x.LinkImagem)
               .HasColumnName("LinkImagem")
               .HasMaxLength(50);

            // relacionamentos
            builder.Property(x => x.IdProduto)
                .HasColumnName("id_Produto")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Imagens)
                .HasForeignKey(x => x.IdProduto);

        }
    }
}
