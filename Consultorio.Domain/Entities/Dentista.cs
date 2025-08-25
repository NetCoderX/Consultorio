using Consultorio.Domain.Excepciones;
using Consultorio.Domain.ObjetosDeValor;

namespace Consultorio.Domain.Entities
{
    public class Dentista
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public Email Email { get; set; } = null!;


        public Dentista(string nombre, Email email)
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
