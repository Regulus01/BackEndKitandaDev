using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Maps;

namespace Repository.Common
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.ApplyConfiguration(new CategoriaProdutoMap());
            modelBuilder.ApplyConfiguration(new ImagemMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
