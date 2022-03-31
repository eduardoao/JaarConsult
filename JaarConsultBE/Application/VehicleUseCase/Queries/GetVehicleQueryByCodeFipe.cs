using Application.Interface;
using Common.Results;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryByCodeFipe : IRequest<Result<Veiculo>>
    {
        public string Code { get; set; }
        public int Year { get; set; }
        public class GetVehicleQueryByCodeFipeHandler : IRequestHandler<GetVehicleQueryByCodeFipe, Result<Veiculo>>
        {
            private readonly IAplicationFipeApi _fipeContext;

            public GetVehicleQueryByCodeFipeHandler(IAplicationFipeApi fipeContext)
            {
                _fipeContext = fipeContext;
            }

            public async Task<Result<Veiculo>> Handle(GetVehicleQueryByCodeFipe request, CancellationToken cancellationToken)
            {
                var veiculoInput = new Veiculo(request.Code, request.Year);
                var resulVehicleFromFipe = _fipeContext.ReturnDataFromFipe(veiculoInput);
                if (resulVehicleFromFipe.Result == null)
                    return await Result<Veiculo>.FailAsync("Nenhum veículo cadastrado com o código digitado!");

                return await Result<Veiculo>.SuccessAsync(resulVehicleFromFipe.Result);

            }
        }

    }
}
