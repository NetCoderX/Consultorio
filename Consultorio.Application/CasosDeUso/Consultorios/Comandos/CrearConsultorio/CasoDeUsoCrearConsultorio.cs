using Consultorio.Application.Interfaces.Repository;
using Consultorio.Domain.Entities;

namespace Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio
    {
        private readonly IRepositoryConsultorio _repositorioConsultorio;
        public CasoDeUsoCrearConsultorio(IRepositoryConsultorio repositoryConsultorio)
        {
            _repositorioConsultorio = repositoryConsultorio;
        }


        public async Task<Guid> Handle(ComandoCrearConsultorio comando, CancellationToken cancellationToken)
        {
            var consultorio = new Domain.Entities.Consultorio(comando.Nombre);

            var respuesta = await _repositorioConsultorio.Agregar(consultorio);

            return respuesta.Id;
        }
    }
}
