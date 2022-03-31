using Application.Interface;
using Common.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryByPlate : IRequest<Result<Veiculo>>
    {
        public string Plate { get; set; }
        public class GetVehicleQueryByCodeHandler : IRequestHandler<GetVehicleQueryByPlate, Result<Veiculo>>
        {
            private readonly IAplicationContextDb _context;

            public GetVehicleQueryByCodeHandler(IAplicationContextDb context)
            {
                _context = context;
            }          

            public async Task<Result<Veiculo>> Handle(GetVehicleQueryByPlate request, CancellationToken cancellationToken)
            {
                var vehicle = _context.Veiculos.Where(a => a.Placa == request.Plate).FirstOrDefault();
                if (vehicle == null)
                    return await Result<Veiculo>.FailAsync("Nenhum veículo cadastrado com a placa digitada!");
                return await Result<Veiculo>.SuccessAsync(vehicle);
            }
        }

    }
}
