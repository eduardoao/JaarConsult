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
    public class UpdateVehicleCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Placa { get;  set; }
        public string Valor { get;  set; }
        public string Marca { get;  set; }
        public string Modelo { get;  set; }
        public int AnoModelo { get;  set; }
        public string Combustivel { get;  set; }
        public string CodigoFipe { get;  set; }
        public string MesReferencia { get;  set; }

        public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Result<Guid>>
        {

            private readonly IAplicationContextDb _context;

            public UpdateVehicleCommandHandler(IAplicationContextDb context)
            {
                _context = context;
            }

            public async Task<Result<Guid>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
            {

                var searchVehicle  = _context.Veiculos.Where(v => v.Id == request.Id).FirstOrDefault();

                if (searchVehicle == null)
                {
                    return await Result<Guid>.FailAsync("Veículo não localizado!");
                }           

                searchVehicle.AnoModelo = request.AnoModelo;
                searchVehicle.CodigoFipe = request.CodigoFipe;
                searchVehicle.Combustivel = request.Combustivel;
                searchVehicle.Marca = request.Marca;
                searchVehicle.MesReferencia = request.MesReferencia;
                searchVehicle.Modelo = request.Modelo;
                searchVehicle.Placa = request.Placa;
                searchVehicle.Valor = request.Valor;

                await _context.SaveChangesAsync();
                return await Result<Guid>.SuccessAsync(searchVehicle.Id, "Veículo atualizado com sucesso!");

            }
        }


    }
}
