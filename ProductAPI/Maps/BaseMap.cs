using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities;

namespace ProductAPI.Maps
{
    public class BaseMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
    {
        private readonly string _tableNome;

        public BaseMap(string tableNome)
        {
            _tableNome = tableNome;
        }

        public void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_tableNome))
            {
                builder.ToTable(_tableNome);
            }

            builder.HasKey(x => _tableNome);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Criacao)
                .HasColumnName("Criacao")
                .IsRequired();
        }
    }
}
