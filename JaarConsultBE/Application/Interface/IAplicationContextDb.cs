using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAplicationContextDb
    {
        DbSet<Domain.Entities.Veiculo> Veiculos { get; set; }
        Task<int> SaveChangesAsync();
    }
}
