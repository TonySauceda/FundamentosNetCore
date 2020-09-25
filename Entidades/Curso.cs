using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }
        public TiposCurso TipoCurso { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public Curso()
        {
            Id = Guid.NewGuid();
        }
    }
}