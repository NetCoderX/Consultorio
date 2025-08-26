
using FluentValidation.Results;

namespace Consultorio.Application.Excepciones
{
    public class ExcepcionDeValidacion : Exception
    {
        private List<string> ErroresDeValidacion { get; set; } = [];

        public ExcepcionDeValidacion(ValidationResult validationResult)
        {
            foreach(var errorDeValidacion in validationResult.Errors)
            {
                ErroresDeValidacion.Add(errorDeValidacion.ErrorMessage);
            }
        }
    }
}
