using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps.User
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                   .HasColumnName("UserName")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnName("Password")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(x => x.Role)
                   .HasColumnName("Role")
                   .IsRequired();

            builder.Property(x => x.Criacao)
                   .HasColumnName("Criacao")
                   .IsRequired();

            builder.HasOne(x => x.Cliente)
                   .WithOne(x => x.Usuario)
                   .HasForeignKey<Cliente>(x => x.UsuarioId);
            
            builder.ToTable("Usuario");
        }
    }
}
