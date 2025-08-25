﻿using Consultorio.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.ObjetosDeValor
{
    public record Email
    {
        public string Value { get; init; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            if (!email.Contains("@"))
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} no es valido");
            
            Value = email;
        }

    }


}
