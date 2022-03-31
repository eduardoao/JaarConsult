using Application.Interface;
using Common.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VehicleUseCase.Commands
{
    public class CreateVehicleCommand: IRequest<Result<Guid>>
    {
        public string Placa { get;  set; }
        public string Valor { get;  set; }
        public string Marca { get;  set; }
        public string Modelo { get;  set; }
        public int AnoModelo { get;  set; }
        public string Combustivel { get;  set; }
        public string CodigoFipe { get;  set; }
        public string MesReferencia { get;  set; }

        public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Result<Guid>>
        {

            private readonly IAplicationContextDb _context;

            public CreateVehicleCommandHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
            {

                var vehicle = _context.Veiculos.Where(a => a.Placa == request.Placa).FirstOrDefault();
                if (vehicle != null)
                {
                    return await Result<Guid>.FailAsync("Veículo já cadastrado!");
                }


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
               
                return await Result<Guid>.SuccessAsync(newVehicle.Id, "Veículo cadastrado com sucesso!");



            }
        }


    }
}
