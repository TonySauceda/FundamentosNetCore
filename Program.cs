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
        const int ELEMENTOS_POR_PAGINA = 10;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();

            var diccionarioObj = engine.ObtenerDiccionarioObjetos();
            var reporteador = new Reporteador(diccionarioObj);

            while (true)
            {
                Clear();
                Printer.DibujarMenuPrincipal(engine.Escuela.Nombre);
                var opcion = ReadKey();
                try
                {
                    switch (opcion.Key)
                    {
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            Clear();
                            WriteLine("Terminando el programa...");
                            return;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            var lsEvaluaciones = reporteador.ObtenerEvaluaciones();
                            if (lsEvaluaciones.Count() == 0)
                                WriteLine("No se encontraron registros");
                            else
                                ReportePaginado(lsEvaluaciones, "Reporte de Evaluaciones");
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            var lsEvalAsig = reporteador.ObtenerEvaluacionesPorAsignatura();
                            if (lsEvalAsig.Count() == 0)
                                WriteLine("No se encontraron registros");
                            else
                                SubMenu(lsEvalAsig, "Reporte de Evaluaciones por Asignatura");
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            var lsPromedio = reporteador.ObtenerPromedioAlumnoPorAsignatura();
                            if (lsPromedio.Count() == 0)
                                WriteLine("No se encontraron registros");
                            else
                                SubMenu(lsPromedio, "Reporte de Promedio Alumno por Asignatura");
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Clear();
                            WriteLine("Ingrese la cantidad Top");
                            var cantidadStr = ReadLine();
                            if (int.TryParse(cantidadStr, out int cantidad))
                            {
                                var lsTopPromedio = reporteador.ObtenerPromedioAlumnoPorAsignatura(cantidad);
                                if (lsTopPromedio.Count() == 0)
                                    WriteLine("No se encontraron registros");
                                else
                                    SubMenu(lsTopPromedio, $"Reporte de Top {cantidad} Promedio Alumno por Asignatura");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    WriteLine("Ocurrió un error inesperado");
                    WriteLine("Volviendo al menú");
                }
                finally
                {
                }
            }
        }

        private static void ReportePaginado(IEnumerable<object> lsElementos, string titulo)
        {
            int pagina = 0;
            int totalPaginas = CalcularTotalPaginas(lsElementos.Count());
            while (true)
            {
                Clear();
                Printer.DibujarTitulo(titulo);
                var lsPagina = lsElementos
                    .Skip(pagina * ELEMENTOS_POR_PAGINA)
                    .Take(ELEMENTOS_POR_PAGINA);

                foreach (var item in lsPagina)
                    WriteLine(item);

                Printer.DibujarPaginador(pagina, totalPaginas);
                if (Paginacion(ref pagina, totalPaginas))
                    return;
            }
        }
        private static void SubMenu(Dictionary<string, IEnumerable<Evaluacion>> elementos, string titulo)
        {
            var asignatuas = elementos.Select(x => x.Key).ToArray();
            while (true)
            {
                Clear();
                Printer.DibujarTitulo(titulo);
                Printer.DibujarMenuAsignaturas(asignatuas);
                var opcion = ReadLine();
                if (int.TryParse(opcion, out int numOpcion))
                {
                    if (numOpcion < 0 || numOpcion > elementos.Count())
                        continue;

                    if (numOpcion == 0)
                    {
                        Clear();
                        return;
                    }
                    else
                        ReportePaginado(elementos[asignatuas[numOpcion - 1]], asignatuas[numOpcion - 1]);
                }
            }
        }
        private static void SubMenu(Dictionary<string, IEnumerable<AlumnoPromedio>> elementos, string titulo)
        {
            var asignatuas = elementos.Select(x => x.Key).ToArray();
            while (true)
            {
                Clear();
                Printer.DibujarTitulo(titulo);
                Printer.DibujarMenuAsignaturas(asignatuas);
                var opcion = ReadLine();
                if (int.TryParse(opcion, out int numOpcion))
                {
                    if (numOpcion < 0 || numOpcion > elementos.Count())
                        continue;

                    if (numOpcion == 0)
                    {
                        Clear();
                        return;
                    }
                    else
                        ReportePaginado(elementos[asignatuas[numOpcion - 1]], asignatuas[numOpcion - 1]);
                }
            }
        }
        private static bool Paginacion(ref int pagina, int totalPaginas)
        {
            var tecla = ReadKey();
            switch (tecla.Key)
            {
                case ConsoleKey.Escape:
                    Clear();
                    return true;
                case ConsoleKey.LeftArrow:
                    if (pagina > 0)
                        pagina--;
                    break;
                case ConsoleKey.RightArrow:
                    WriteLine(pagina);
                    WriteLine(totalPaginas);
                    if (pagina + 1 < totalPaginas)
                        pagina++;
                    break;
            }

            return false;
        }

        private static int CalcularTotalPaginas(int totalElementos)
        {
            int totalPaginas = totalElementos / ELEMENTOS_POR_PAGINA;
            if ((totalElementos % ELEMENTOS_POR_PAGINA) != 0)
                totalPaginas++;

            return totalPaginas;
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.DibujarTitulo("Saliendo");
            Printer.Beep(3000, 600, 3);
            Printer.DibujarTitulo("Salió");
        }
    }
}
