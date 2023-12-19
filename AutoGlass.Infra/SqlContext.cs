using Microsoft.EntityFrameworkCore;
using AutoGlass.Domain.Models;
using AutoGlass.Infra.EntityFrameworkMapping;

namespace AutoGlass.Infra
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> opcoes) : base(opcoes)
        {

        }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
