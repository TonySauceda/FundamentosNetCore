using System;
using System.Collections.Generic;
using System.Linq;
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
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.DibujarTitulo("Evaluaciones de los Alumnos");
            // engine.ImprimirEvaluaciones();

            Printer.DibujarTitulo("Pruebas de polimorfismo");
            var alumnoTest = new Alumno() { Nombre = "Tony Sauceda" };
            ObjetoEscuelaBase objeto = alumnoTest;
            WriteLine($"Alumno: {alumnoTest.Nombre}, Id: {alumnoTest.Id}, Tipo: {alumnoTest.GetType()}");
            WriteLine($"Alumno: {objeto.Nombre}, Id: {objeto.Id}, Tipo: {objeto.GetType()}");

            int dummy = 0;
            var listaObjetos = engine.ObtenerListaObtetosEscuela(out dummy, out dummy, out dummy, out int contadorEvaluaciones);
            // engine.Escuela.LimpiarLugar();

            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

            var diccionarioObj = engine.ObtenerDiccionarioObjetos();
            engine.ImprimirDiccionario(diccionarioObj, true);
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.DibujarTitulo("Saliendo");
            Printer.Beep(3000, 600, 3);
            Printer.DibujarTitulo("Salió");
        }
    }
}
