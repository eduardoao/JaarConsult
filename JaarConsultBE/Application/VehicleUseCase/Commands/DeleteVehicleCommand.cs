using Application.Interface;
using Common.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Commands
{
    public class DeleteVehicleCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Result<Guid>>
        {

            private readonly IAplicationContextDb _context;

            public DeleteVehicleCommandHandler(IAplicationContextDb context)
            {
                _context = context;
            }         

            public async Task<Result<Guid>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
            {
                var vehicle = await _context.Veiculos.Where(v => v.Id == request.Id).FirstOrDefaultAsync();

                if (vehicle == null)
                {
                    return await Result<Guid>.FailAsync("Veículo não localizado!");
                }
                
                _context.Veiculos.Remove(vehicle);
                await _context.SaveChangesAsync();             
                return await Result<Guid>.SuccessAsync(vehicle.Id, "Veículo removido com sucesso!");
            }
        }


    }
}
