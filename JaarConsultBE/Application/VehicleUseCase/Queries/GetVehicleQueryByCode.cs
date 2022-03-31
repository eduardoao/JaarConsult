using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryByCode : IRequest<Veiculo>
    {
        public string Code { get; set; }
        public class GetVehicleQueryByCodeHandler : IRequestHandler<GetVehicleQueryByCode, Veiculo>
        {
            private readonly IAplicationContextDb _context;

            public GetVehicleQueryByCodeHandler(IAplicationContextDb context)
            {
                _context = context;
            }          

            public async Task<Veiculo> Handle(GetVehicleQueryByCode request, CancellationToken cancellationToken)
            {
                var vehicle = _context.Veiculos.Where(a => a.CodigoFipe == request.Code).FirstOrDefault();
                if (vehicle == null) return null;
                return vehicle;
            }
        }

    }
}
