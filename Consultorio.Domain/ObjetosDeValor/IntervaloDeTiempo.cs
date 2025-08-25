using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.ObjetosDeValor
{
    public record IntervaloDeTiempo
    {
        public DateTime Inicio { get; init; }
        public DateTime Fin { get; init; }
        public IntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            if(inicio >= fin)
                throw new Excepciones.ExcepcionDeReglaDeNegocio("La fecha de inicio no puede ser posterior o igual a la fecha de fin");

            Inicio = inicio;
            Fin = fin;
        }
    }
}
