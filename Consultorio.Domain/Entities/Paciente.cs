using Consultorio.Domain.Excepciones;
using Consultorio.Domain.ObjetosDeValor;

namespace Consultorio.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nombre { get;private set; }
        public Email Email { get;private set; }


        public Paciente(string nombre, Email email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            if (email is null)
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");


            Id = Guid.CreateVersion7();
            Nombre = nombre;
            Email = email;
        }
    }
}
