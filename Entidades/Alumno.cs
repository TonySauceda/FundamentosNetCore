using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }
        public List<Evaluaciones> Evaluaciones { get; set; }
        public Alumno() => Id = Guid.NewGuid();

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}";
        }
    }
}