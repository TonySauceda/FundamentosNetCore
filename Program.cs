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
            // engine.ImprimirDiccionario(diccionarioObj, true);

            var reporteador = new Reporteador(diccionarioObj);
            var lsEvaluaciones = reporteador.ObtenerEvaluaciones();
            var lsEvaluacionesPorAsignatura = reporteador.ObtenerEvaluacionesPorAsignatura();
            var promedioAlumnosPorAsig = reporteador.ObtenerPromedioAlumnoPorAsignatura();
            var topAlumnosPorAsig = reporteador.ObtenerPromedioAlumnoPorAsignatura(3);

            Printer.DibujarTitulo("Captura de una evaluación por consola");
            var nuevaEvaluacion = new Evaluacion();
            string nombre = "";
            string calificacionStr = "";
            float calificacion = 0;
            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
                WriteLine("El valor del nombre no puede ser vacio");

            nuevaEvaluacion.Nombre = nombre;
            WriteLine("El nombre ha sido capturado correctamente");

            WriteLine("Ingrese la calificación de la evaluación");
            Printer.PresioneEnter();
            calificacionStr = ReadLine();
            if (string.IsNullOrWhiteSpace(calificacionStr))
                WriteLine("El valor de la calificación no puede ser vacio");
            else
            {
                try
                {
                    calificacion = float.Parse(calificacionStr);
                    WriteLine("El valor de la calificación no tiene el formato correcto"); if (calificacion < 0 && calificacion > 5)
                        throw new ArgumentOutOfRangeException("La calificacion debe estar entre 0 y 5");
                    else
                    {
                        nuevaEvaluacion.Calificacion = calificacion;
                        WriteLine("La calificación ha sido capturada correctamente");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    WriteLine("El valor de la calificación tiene un formato incorrecto");
                }
                finally
                {
                    Printer.DibujarTitulo("finally");
                }
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.DibujarTitulo("Saliendo");
            Printer.Beep(3000, 600, 3);
            Printer.DibujarTitulo("Salió");
        }
    }
}
