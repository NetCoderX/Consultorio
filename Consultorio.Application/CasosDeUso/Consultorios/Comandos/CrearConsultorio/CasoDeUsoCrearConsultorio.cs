using Consultorio.Application.Excepciones;
using Consultorio.Application.Interfaces.Persistencia;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Application.Utilidades.Mediador;
using Consultorio.Domain.Entities;
using FluentValidation;

namespace Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio : IRequestHandler<ComandoCrearConsultorio, Guid>
    {
        private readonly IRepositoryConsultorio _repositorioConsultorio;
        private readonly IUnitOfWork _unitOfWork;   
  
        public CasoDeUsoCrearConsultorio(IRepositoryConsultorio repositoryConsultorio, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositorioConsultorio = repositoryConsultorio;
        }


        public async Task<Guid> Handle(ComandoCrearConsultorio comando)
        {
            var consultorio = new Domain.Entities.Consultorio(comando.Nombre);

            try
            {
                var respuesta = await _repositorioConsultorio.Agregar(consultorio);
                await _unitOfWork.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Reversar();
                throw;
            }
        }
    }
}
