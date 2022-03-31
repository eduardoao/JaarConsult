using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetAllVehiclesQuery: IRequest<IEnumerable<Domain.Entities.Veiculo>>
    {
        public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Domain.Entities.Veiculo>>
        {
            private readonly IAplicationContextDb _context;

            public GetAllVehiclesQueryHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Domain.Entities.Veiculo>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
            {
                var vehicleList = await _context.Veiculos.ToListAsync();
                if (vehicleList == null)         
                    return null;                
                return vehicleList.AsReadOnly();
            }
        }
    }
}
