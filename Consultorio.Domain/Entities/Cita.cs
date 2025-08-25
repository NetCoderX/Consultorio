using Consultorio.Domain.Enums;
using Consultorio.Domain.ObjetosDeValor;

namespace Consultorio.Domain.Entities
{
    public class Cita
    {
        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; }
        public Guid DentistaId { get; private set; }
        public Guid ConsultorioId { get; private set; }
        public EstadoCita Estado { get; private set; }
        public IntervaloDeTiempo IntervaloDeTiempo { get; private set; }
        public Paciente? Paciente { get; private set; }
        public Dentista? Dentista { get; private set; }
        public Consultorio? Consultorio { get; private set; }


        public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, IntervaloDeTiempo intervaloDeTiempo)
        {

            if (intervaloDeTiempo.Inicio < DateTime.UtcNow)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La fecha de inicio no puede ser anterior a la fecha actual");

            PacienteId = pacienteId;
            DentistaId = dentistaId;
            ConsultorioId = consultorioId;
            IntervaloDeTiempo = intervaloDeTiempo;
            Estado = EstadoCita.Programada;
            Id = Guid.CreateVersion7();
        }

        public void Cancelar()
        {
            if (Estado != EstadoCita.Programada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("Solo se pueden cancelar citas programadas");
            if (Estado == EstadoCita.Cancelada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La cita ya está cancelada");
            if (Estado == EstadoCita.Completada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La cita ya está finalizada");

            Estado = EstadoCita.Cancelada;
        }

        public void Completar()
        {
            if (Estado != EstadoCita.Programada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("Solo se pueden completar citas programadas");
            if (Estado == EstadoCita.Cancelada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La cita ya está cancelada");
            if (Estado == EstadoCita.Completada)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La cita ya está finalizada");
            Estado = EstadoCita.Completada;



        }
    }
}
