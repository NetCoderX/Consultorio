using Consultorio.Domain.Entities;
using Consultorio.Domain.Excepciones;
using Consultorio.Domain.ObjetosDeValor;

namespace Consultorio.Test.Domain.Entities
{
    [TestClass]
    public class PacienteTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaExcepcion()
        {
            var email = new Email("hernan@gmail.com");
            new Paciente(null!, email);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_EmailNulo_LanzaExcepcion()
        {
            Email email = null!;
            new Paciente("hernan", email);
        }
    }
}
