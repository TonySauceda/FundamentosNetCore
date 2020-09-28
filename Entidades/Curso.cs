using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {
        public TiposCurso TipoCurso { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DibujarLiena();
            Console.WriteLine("Limpiando Curso");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
    }
}