using Application.Interface;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryByCodeFipe : IRequest<Veiculo>
    {
        public string Code { get; set; }
        public int Year { get; set; }
        public class GetVehicleQueryByCodeFipeHandler : IRequestHandler<GetVehicleQueryByCodeFipe, Veiculo>
        {
            private readonly IAplicationFipeApi _fipeContext;

            public GetVehicleQueryByCodeFipeHandler(IAplicationFipeApi fipeContext)
            {
                _fipeContext = fipeContext;
            }

            public  Task<Veiculo> Handle(GetVehicleQueryByCodeFipe request, CancellationToken cancellationToken)
            {
                var veiculoInput = new Veiculo(request.Code, request.Year);
                var resulVehicleFromFipe = _fipeContext.ReturnDataFromFipe(veiculoInput);
                return  resulVehicleFromFipe;
              
            }
        }

    }
}
