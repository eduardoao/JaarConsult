using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAplicationFipeApi
    {
        Task<Domain.Entities.Veiculo> ReturnDataFromFipe(Domain.Entities.Veiculo veiculo); 
    }
}
