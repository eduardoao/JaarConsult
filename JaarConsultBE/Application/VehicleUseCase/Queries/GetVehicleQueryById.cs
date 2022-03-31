using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetVehicleQueryById: IRequest<Veiculo>
    {
        public Guid Id { get; set; }
        public class GetVehicleQueryByPlateHandler : IRequestHandler<GetVehicleQueryById, Veiculo>
        {
            private readonly IAplicationContextDb _context;

            public GetVehicleQueryByPlateHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<Veiculo> Handle(GetVehicleQueryById request, CancellationToken cancellationToken)
            {
                var vehicle =  _context.Veiculos.Where(a => a.Id == request.Id).FirstOrDefault();
                if (vehicle == null) return null;
                return vehicle;
            }
        }

    }
}
