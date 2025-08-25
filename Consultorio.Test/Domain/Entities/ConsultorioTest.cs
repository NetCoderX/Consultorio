using Consultorio.Domain.Excepciones;


namespace Consultorio.Test.Domain.Entities
{
    [TestClass]
    public class ConsultorioTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaExcepcion()
        {
            new Consultorio.Domain.Entities.Consultorio(null!);
        }
    }
}
