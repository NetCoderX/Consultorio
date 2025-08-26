using FluentValidation;

namespace Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class ValidadorComandoCrearConsultorio : AbstractValidator<ComandoCrearConsultorio>
    {


        public ValidadorComandoCrearConsultorio()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
