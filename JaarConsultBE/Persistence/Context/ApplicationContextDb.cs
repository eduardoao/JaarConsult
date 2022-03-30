using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationContextDb : DbContext, IAplicationContextDb
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>().Property(p => p.Valor).HasColumnType("decimal(10, 2)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
