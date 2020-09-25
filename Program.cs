using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();

            // engine.Escuela.ImprimirCursos();

            // Printer.DibujarTitulo("Titulo chingon");

            Printer.DibujarTitulo("Evaluaciones de los Alumnos");
            engine.ImprimirEvaluaciones();
        }
    }
}
