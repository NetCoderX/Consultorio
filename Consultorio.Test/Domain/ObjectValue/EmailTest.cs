using Consultorio.Domain.Excepciones;
using Consultorio.Domain.ObjetosDeValor;

namespace Consultorio.Test.Domain.ObjectValue
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_EmailNulo_LanzaExcepcion()
        {
            new Email(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_EmailSinArroba_LanzaExcepcion()
        {
            new Email("hernan.com");
        }

        [TestMethod]
        public void Constructor_EmailValido_NoLanzaExcepcion()
        {
            new Email("hernan@gmail.com");
        }
    }
}
