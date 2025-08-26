

namespace Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public static class MapeadorExtensions
    {

        public static ConsultorioDetalleDTO ADto(this Consultorio.Domain.Entities.Consultorio consultorio)
        {

            var dto = new ConsultorioDetalleDTO { Id = consultorio.Id, Nombre = consultorio.Nombre };
            return dto;
        }
    }
}
