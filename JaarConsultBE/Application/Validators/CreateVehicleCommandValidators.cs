using Application.VehicleUseCase.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateVehicleCommandValidators : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidators()
        {           
            RuleFor(v => v.Valor).NotEmpty();
            RuleFor(v => v.AnoModelo).NotEmpty();
            RuleFor(v => v.CodigoFipe).NotEmpty();
            RuleFor(v => v.Combustivel).NotEmpty();          
            RuleFor(v => v.Marca).NotEmpty();
            RuleFor(v => v.Placa).NotEmpty();
            RuleFor(v => v.MesReferencia).NotEmpty();
        }
    }
}
