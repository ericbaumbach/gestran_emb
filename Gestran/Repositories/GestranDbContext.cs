using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Gestran.Repositories
{
    public class GestranDbContext : DbContext
    {
        public GestranDbContext(DbContextOptions<GestranDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne<Fornecedor>(s => s.Fornecedor)
                .WithMany(g => g.Enderecos)
                .HasForeignKey(s => s.FornecedorId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
