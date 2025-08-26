using Consultorio.Application.Utilidades.Mediador;

namespace Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public class ConsultaObtenerDetalleConsultorio : IRequest<ConsultorioDetalleDTO>
    {
        public Guid Id { get; set; }
    }
}
