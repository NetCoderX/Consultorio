using Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using Consultorio.Application.Excepciones;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Consultorio.Test.Application.CasosDeUso.Consultorios
{
    [TestClass]
    public class CasoDeUsoObtenerDetalleConsultorioTest
    {
        private IRepositoryConsultorio _repositoryConsultorio;
        private CasoDeUsoObtenerDetalleConsultorio _casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            _repositoryConsultorio = Substitute.For<IRepositoryConsultorio>();
            _casoDeUso = new CasoDeUsoObtenerDetalleConsultorio(_repositoryConsultorio);
        }

        [TestMethod]
        public async Task Handle_ConsultorioExiste_RetornaDTO()
        {
            var consultorio = new Consultorio.Domain.Entities.Consultorio("Consultorio A");
            var id = consultorio.Id;
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };
            _repositoryConsultorio.ObtenerPorId(id).Returns(consultorio);

            var resultado = await _casoDeUso.Handle(consulta);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(id, resultado.Id);
            Assert.AreEqual("Consultorio A", resultado.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_ConsultorioNoExiste_LanzaExcepcionNoEncontrado()
        {
            var id = Guid.NewGuid();
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };
            _repositoryConsultorio.ObtenerPorId(id).ReturnsNull();

            await _casoDeUso.Handle(consulta);
        }
    }
}
