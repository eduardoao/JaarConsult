using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAplicationContextDb
    {
        DbSet<Veiculo> Veiculos { get; set; }
        Task<int> SaveChangesAsync();
    }
}
