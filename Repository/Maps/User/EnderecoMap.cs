using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps.User;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(x => x.EnderecoId);
        builder.Property(x => x.EnderecoId)
            .HasColumnName("EnderecoId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UF)
            .HasColumnName("UF")
            .HasMaxLength(2);
        
        builder.Property(x => x.Cidade)
            .HasColumnName("Cidade")
            .HasMaxLength(50);
        
        builder.Property(x => x.Bairro)
            .HasColumnName("Bairro")
            .HasMaxLength(80);

        builder.Property(x => x.Cep)
            .HasColumnName("Cep")
            .HasMaxLength(8);

        builder.Property(x => x.Referencia)
            .HasColumnName("Referencia")
            .HasMaxLength(80);
        
        //Cliente
        builder.HasOne(x => x.Cliente)
            .WithOne(x => x.Endereco)
            .HasForeignKey<Cliente>(x => x.EnderecoId);

        builder.ToTable("Endereco");
    }
}