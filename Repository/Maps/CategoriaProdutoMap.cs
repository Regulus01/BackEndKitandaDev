using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{

    public class CategoriaProdutoMap : BaseMap<CategoriaProduto>
    {
        public CategoriaProdutoMap(string tableNome) : base(tableNome)
        {
        }

        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome)
                 .HasColumnName("nome")
                 .HasMaxLength(50)
                 .IsRequired();
        }
    }

}
