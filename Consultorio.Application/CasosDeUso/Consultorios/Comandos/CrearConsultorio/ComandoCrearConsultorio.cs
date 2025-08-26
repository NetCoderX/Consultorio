using Consultorio.Application.Utilidades.Mediador;

namespace Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class ComandoCrearConsultorio : IRequest<Guid>
    {
        public required string Nombre { get; set; }
    }
}
