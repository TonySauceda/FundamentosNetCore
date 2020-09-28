using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Secundaria, "Colombia", "Bogota");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        public IReadOnlyList<ObjetoEscuelaBase> ObtenerListaObtetosEscuela(
            bool incluirCursos = true,
            bool incluirAsignaturas = true,
            bool incluirAlumnos = true,
            bool incluirEvaluaciones = true)
        {
            return ObtenerListaObtetosEscuela(out int dummy, out dummy, out dummy, out dummy, incluirCursos, incluirAsignaturas, incluirAlumnos, incluirEvaluaciones);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerListaObtetosEscuela(
            out int totalCursos,
            bool incluirCursos = true,
            bool incluirAsignaturas = true,
            bool incluirAlumnos = true,
            bool incluirEvaluaciones = true)
        {
            return ObtenerListaObtetosEscuela(out totalCursos, out int dummy, out dummy, out dummy, incluirCursos, incluirAsignaturas, incluirAlumnos, incluirEvaluaciones);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerListaObtetosEscuela(
            out int totalCursos,
            out int totalAsignaturas,
            bool incluirCursos = true,
            bool incluirAsignaturas = true,
            bool incluirAlumnos = true,
            bool incluirEvaluaciones = true)
        {
            return ObtenerListaObtetosEscuela(out totalCursos, out totalAsignaturas, out int dummy, out dummy, incluirCursos, incluirAsignaturas, incluirAlumnos, incluirEvaluaciones);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerListaObtetosEscuela(
            out int totalCursos,
            out int totalAsignaturas,
            out int totalAlumnos,
            bool incluirCursos = true,
            bool incluirAsignaturas = true,
            bool incluirAlumnos = true,
            bool incluirEvaluaciones = true)
        {
            return ObtenerListaObtetosEscuela(out totalCursos, out totalAsignaturas, out totalAlumnos, out int dummy, incluirCursos, incluirAsignaturas, incluirAlumnos, incluirEvaluaciones);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerListaObtetosEscuela(
            out int totalCursos,
            out int totalAsignaturas,
            out int totalAlumnos,
            out int totalEvaluaciones,
            bool incluirCursos = true,
            bool incluirAsignaturas = true,
            bool incluirAlumnos = true,
            bool incluirEvaluaciones = true)
        {
            totalCursos = totalAsignaturas = totalAlumnos = totalEvaluaciones = 0;

            var resultado = new List<ObjetoEscuelaBase>();
            resultado.Add(Escuela);
            if (incluirCursos)
            {
                resultado.AddRange(Escuela.Cursos);
                totalCursos = Escuela.Cursos.Count;
            }

            foreach (var curso in Escuela.Cursos)
            {
                if (incluirAsignaturas)
                {
                    resultado.AddRange(curso.Asignaturas);
                    totalAsignaturas += curso.Asignaturas.Count;
                }
                if (incluirAlumnos)
                {
                    resultado.AddRange(curso.Alumnos);
                    totalAlumnos += curso.Alumnos.Count;
                }
                if (incluirEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        resultado.AddRange(alumno.Evaluaciones);
                        totalEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return resultado;
        }
        public void ImprimirEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {
                    Printer.DibujarTitulo(alumno.ToString());
                    foreach (var evaluacion in alumno.Evaluaciones)
                    {
                        Console.WriteLine(evaluacion.ToString());
                    }
                }
            }
        }
        #region Métodos de Carga
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {
                    var rand = new Random();
                    foreach (var asignatura in curso.Asignaturas)
                    {
                        alumno.Evaluaciones.Add(new Evaluacion
                        {
                            Alumno = alumno,
                            Asignatura = asignatura,
                            Nombre = $"Evaluación: {asignatura.Nombre}",
                            Calificacion = (float)rand.NextDouble() * 5
                        });
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){ Nombre = "Matemáticas" },
                    new Asignatura(){ Nombre = "Educación Física" },
                    new Asignatura(){ Nombre = "Español" },
                    new Asignatura(){ Nombre = "Ciencias Naturales" },
                    new Asignatura(){ Nombre = "Programación Básica" },
                };
                curso.Asignaturas = (listaAsignaturas);
            }
        }

        private List<Alumno> CargarAlumnos()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = (from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno() { Nombre = $"{n1} {n2} {a1}" });

            return listaAlumnos.OrderBy(x => x.Id).Take(new Random().Next(15, 50)).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>
            {
                new Curso(){ Nombre = "101", TipoCurso = TiposCurso.Mañana },
                new Curso(){ Nombre = "201", TipoCurso = TiposCurso.Mañana },
                new Curso(){ Nombre = "301", TipoCurso = TiposCurso.Mañana },
                new Curso(){ Nombre = "102", TipoCurso = TiposCurso.Tarde },
                new Curso(){ Nombre = "202", TipoCurso = TiposCurso.Tarde },
                new Curso(){ Nombre = "302", TipoCurso = TiposCurso.Tarde },
                new Curso(){ Nombre = "103", TipoCurso = TiposCurso.Noche },
                new Curso(){ Nombre = "203", TipoCurso = TiposCurso.Noche },
                new Curso(){ Nombre = "303", TipoCurso = TiposCurso.Noche },
            };

            foreach (var curso in Escuela.Cursos)
                curso.Alumnos = (CargarAlumnos());
        }

        #endregion
    }
}