using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps.User;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.ClienteId);
        builder.Property(x => x.ClienteId)
            .HasColumnName("ClienteId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.NomeCliente)
            .HasColumnName("NomeCliente")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Telefone)
            .HasColumnName("Telefone")
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(x => x.ClienteId)
            .HasColumnName("Cliente_Id")
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnName("UsuarioId")
            .IsRequired();
        
        //Endereco
        builder.Property(x => x.EnderecoId)
            .HasColumnName("EnderecoId")
            .IsRequired();
        
        builder.ToTable("Cliente");
    }
}