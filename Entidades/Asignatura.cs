using System;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }

        public Asignatura() => Id = Guid.NewGuid();
    }
}