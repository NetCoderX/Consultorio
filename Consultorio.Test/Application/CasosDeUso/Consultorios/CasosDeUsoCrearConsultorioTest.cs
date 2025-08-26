using Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using Consultorio.Application.Excepciones;
using Consultorio.Application.Interfaces.Persistencia;
using Consultorio.Application.Interfaces.Repository;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Consultorio.Test.Application.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasosDeUsoCrearConsultorioTest
    {
        private IRepositoryConsultorio _repositorioConsultorio;
        private IUnitOfWork _unitOfWork;
        private CasoDeUsoCrearConsultorio _casoDeUsoCrearConsultorio;

        [TestInitialize]
        public void Setup()
        {
            _repositorioConsultorio = Substitute.For<IRepositoryConsultorio>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _casoDeUsoCrearConsultorio = new CasoDeUsoCrearConsultorio(_repositorioConsultorio, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenemosIdConsultorio()
        {
            var comando = new ComandoCrearConsultorio { Nombre = "Consultorio A" };

            var consultorioCreado = new Consultorio.Domain.Entities.Consultorio("Consultorio A");
            _repositorioConsultorio.Agregar(Arg.Any<Consultorio.Domain.Entities.Consultorio>()).Returns(consultorioCreado);

            var resultado = await _casoDeUsoCrearConsultorio.Handle(comando);
            await _repositorioConsultorio.Received(1).Agregar(Arg.Any<Consultorio.Domain.Entities.Consultorio>());
            await _unitOfWork.Received(1).Persistir();
            Assert.AreNotEqual(Guid.Empty, resultado);
        }



        [TestMethod]
        public async Task Handle_CuandoHayError_HacemosRollback()
        {
            var comando = new ComandoCrearConsultorio { Nombre = "Consultorio A" };
            _repositorioConsultorio.Agregar(Arg.Any<Consultorio.Domain.Entities.Consultorio>()).Throws<Exception>();

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                var resultado = await _casoDeUsoCrearConsultorio.Handle(comando);
            });
            await _unitOfWork.Received(1).Reversar();
        }


    }
}
