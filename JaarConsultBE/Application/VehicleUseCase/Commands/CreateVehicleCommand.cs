using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Commands
{
    public class CreateVehicleCommand: IRequest<Guid>
    {
        public string Placa { get;  set; }
        public decimal Valor { get;  set; }
        public string Marca { get;  set; }
        public string Modelo { get;  set; }
        public int AnoModelo { get;  set; }
        public string Combustivel { get;  set; }
        public string CodigoFipe { get;  set; }
        public string MesReferencia { get;  set; }

        public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
        {

            private readonly IAplicationContextDb _context;

            public CreateVehicleCommandHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
            {
                var newVehicle = new Veiculo(
                    request.Placa, 
                    request.Valor,                  
                    request.Modelo,
                    request.Marca,
                    request.AnoModelo, 
                    request.Combustivel, 
                    request.CodigoFipe, 
                    request.MesReferencia
                    );

                _context.Veiculos.Add(newVehicle);
                await _context.SaveChangesAsync();
                return newVehicle.Id;



            }
        }


    }
}
