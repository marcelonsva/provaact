using ConsultaCep.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
               .ToTable("Cliente")
               .HasKey(c => c.ClienteID);

        }
    }
}
