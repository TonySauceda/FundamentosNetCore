using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario)
        {
            if (diccionario == null)
                throw new ArgumentNullException(nameof(diccionario));
            _diccionario = diccionario;
        }

        public IEnumerable<Evaluacion> ObtenerEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out var resultado))
            {
                return resultado.Cast<Evaluacion>();
            }

            return new List<Evaluacion>();
        }

        public IEnumerable<string> ObtenerAsignaturas(out IEnumerable<Evaluacion> lsEvaluaciones)
        {
            lsEvaluaciones = ObtenerEvaluaciones();
            return lsEvaluaciones.Select(x => x.Nombre).Distinct().ToList();
        }
        public IEnumerable<string> ObtenerAsignaturas()
        {
            return ObtenerAsignaturas(out var dummy);
        }

        public Dictionary<string, IEnumerable<Evaluacion>> ObtenerEvaluacionesPorAsignatura()
        {
            var resultado = new Dictionary<string, IEnumerable<Evaluacion>>();

            var lsAsignaturas = ObtenerAsignaturas(out var lsEvaluaciones);
            foreach (var asignatura in lsAsignaturas)
            {
                var evaluaciones = lsEvaluaciones.Where(x => x.Asignatura.Nombre == asignatura).ToList();
                resultado.Add(asignatura, evaluaciones);
            }

            return resultado;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> ObtenerPromedioAlumnoPorAsignatura()
        {
            var resultado = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var diccEvaluacionesAsignatura = ObtenerEvaluacionesPorAsignatura();

            foreach (var evalAsig in diccEvaluacionesAsignatura)
            {
                var promedioAlumnos = evalAsig.Value
                    .GroupBy(x => new { AlumnoId = x.Alumno.Id, Nombre = x.Alumno.Nombre })
                    .Select(x => new AlumnoPromedio
                    {
                        Id = x.Key.AlumnoId,
                        Nombre = x.Key.Nombre,
                        Promedio = x.Average(calif => calif.Calificacion)
                    });

                resultado.Add(evalAsig.Key, promedioAlumnos);
            }

            return resultado;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> ObtenerPromedioAlumnoPorAsignatura(int top)
        {
            var resultado = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var promedioAlumnos = ObtenerPromedioAlumnoPorAsignatura();

            foreach (var promedio in promedioAlumnos)
            {
                var topAlumnos = promedio.Value
                    .OrderByDescending(x => x.Promedio)
                    .Take(top);

                resultado.Add(promedio.Key, topAlumnos);
            }
            return resultado;
        }
    }
}