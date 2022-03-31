using Application.Interface;
using Common.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Queries
{
    public class GetAllVehiclesQuery: IRequest<Result<IEnumerable<Veiculo>>>
    {
        public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, Result<IEnumerable<Veiculo>>>
        {
            private readonly IAplicationContextDb _context;

            public GetAllVehiclesQueryHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<Result<IEnumerable<Veiculo>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
            {
                var vehicleList = await _context.Veiculos.ToListAsync();
                if (vehicleList.Count == 0)               
                    return await Result<IEnumerable<Veiculo>>.FailAsync("Nenhum veículo cadastrado!");

                return await Result<IEnumerable<Veiculo>>.SuccessAsync(vehicleList);
                
            }
          
        }
    }
}
