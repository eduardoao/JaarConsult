using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAplicationFipeApi
    {
        Task<Veiculo> ReturnDataFromFipe(Veiculo veiculo); 
    }
}
