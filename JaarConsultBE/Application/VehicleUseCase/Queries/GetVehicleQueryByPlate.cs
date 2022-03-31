using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryByPlate : IRequest<Veiculo>
    {
        public string Plate { get; set; }
        public class GetVehicleQueryByCodeHandler : IRequestHandler<GetVehicleQueryByPlate, Veiculo>
        {
            private readonly IAplicationContextDb _context;

            public GetVehicleQueryByCodeHandler(IAplicationContextDb context)
            {
                _context = context;
            }          

            public async Task<Veiculo> Handle(GetVehicleQueryByPlate request, CancellationToken cancellationToken)
            {
                var vehicle = _context.Veiculos.Where(a => a.Placa == request.Plate).FirstOrDefault();
                if (vehicle == null) return null;
                return vehicle;
            }
        }

    }
}
