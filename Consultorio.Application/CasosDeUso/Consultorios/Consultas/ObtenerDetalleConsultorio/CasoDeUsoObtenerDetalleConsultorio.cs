using Consultorio.Application.Excepciones;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Application.Utilidades.Mediador;

namespace Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public class CasoDeUsoObtenerDetalleConsultorio : IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>
    {

        private readonly IRepositoryConsultorio _repositoryConsultorio;
        public CasoDeUsoObtenerDetalleConsultorio(IRepositoryConsultorio repositoryConsultorio)
        {
            _repositoryConsultorio = repositoryConsultorio;
        }

        public async Task<ConsultorioDetalleDTO> Handle(ConsultaObtenerDetalleConsultorio request)
        {
            var consultorio = await _repositoryConsultorio.ObtenerPorId(request.Id);
            if (consultorio is null)
                throw new ExcepcionNoEncontrado();
            return consultorio.ADto();
        }
    }
}
