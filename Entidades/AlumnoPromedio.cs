using System;

namespace CoreEscuela.Entidades
{
    public class AlumnoPromedio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Promedio { get; set; }

        public override string ToString()
        {
            return $"{Promedio}, {Nombre}";
        }
    }
}