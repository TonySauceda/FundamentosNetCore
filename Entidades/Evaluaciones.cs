using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Calificacion { get; set; }

        public override string ToString()
        {
            return $"{Asignatura.Nombre}: {((decimal)Calificacion).ToString("N2")}";
        }
    }
}