using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Commands
{
    public class DeleteVehicleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Guid>
        {

            private readonly IAplicationContextDb _context;

            public DeleteVehicleCommandHandler(IAplicationContextDb context)
            {
                _context = context;
            }         

            public async Task<Guid> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
            {
                var vehicle = await _context.Veiculos.Where(v => v.Id == request.Id).FirstOrDefaultAsync();

                if (vehicle == null) return default;
                _context.Veiculos.Remove(vehicle);
                await _context.SaveChangesAsync();
                return vehicle.Id;
            }
        }


    }
}
