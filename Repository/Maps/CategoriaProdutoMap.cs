using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class CategoriaProdutoMap : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Nome)
                 .HasColumnName("nome")
                 .HasMaxLength(50)
                 .IsRequired();

            builder.ToTable("CategoriaProduto");
        }
    }

}
