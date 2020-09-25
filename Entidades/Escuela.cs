using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase
    {
        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            Nombre = nombre;
            AñoDeCreación = año;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}{Environment.NewLine}Tipo: {TipoEscuela}{Environment.NewLine}Pais: {Pais}{Environment.NewLine}Ciudad: {Ciudad}";
        }

        public void ImprimirCursos()
        {
            if (Cursos != null)
                foreach (var item in Cursos)
                    Console.WriteLine($"Nombre: {item.Nombre}, Tipo: {item.TipoCurso}, CursoId: {item.Id}");
        }
    }
}