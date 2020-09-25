using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Calificacion { get; set; }

        public Evaluaciones() => Id = Guid.NewGuid();

        public override string ToString()
        {
            return $"{Asignatura.Nombre}: {((decimal)Calificacion).ToString("N2")}";
        }
    }
}