using System;
using static System.Console;
namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLiena(int tamaño = 100)
        {
            WriteLine("".PadLeft(tamaño, '='));
        }
        public static void DibujarTitulo(string titulo)
        {
            int tamañoLinea = titulo.Length > 100 ? 200 : 100;
            int pad = titulo.Length > tamañoLinea ? 0 : ((tamañoLinea - titulo.Length) / 2);
            DibujarLiena(tamañoLinea);
            WriteLine($"{"".PadRight(pad, ' ')}{titulo.ToUpper()}");
            DibujarLiena(tamañoLinea);
        }
        public static void Beep(int hz, int duracion, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
                Console.Beep(hz, duracion);
        }

        public static void PresioneEnter()
        {
            WriteLine("Presione ENTER para continuar");
        }
        public static void DibujarMenuPrincipal(string titulo)
        {
            Printer.DibujarTitulo(titulo);
            WriteLine("1 - Evaluaciones");
            WriteLine("2 - Evaluaciones por asignatura");
            WriteLine("3 - Promedio por asignatura");
            WriteLine("4 - Top alumnos por asignatura");
            WriteLine("0 - Terminar programa");
            WriteLine("Ingrese una opción");
        }

        public static void DibujarMenuAsignaturas(string[] asignaturas)
        {
            int cont = 1;
            foreach (var item in asignaturas)
            {
                WriteLine($"{cont++} - {item}");
            }
            WriteLine("0 - Regresar al menú principal");
            WriteLine("Seleccione una opción");
        }

        public static void DibujarPaginador(int pagina, int totalPaginas)
        {
            if (totalPaginas == 1)
            {
                WriteLine("Precione Esc para regresar al menú");
            }
            else
            {
                WriteLine($"Página: {pagina + 1} de {totalPaginas}");
                WriteLine("Precione <- para ir a la página anterior, -> para ir a la página siguiente ó Esc para regresar al menú");
            }
        }
    }
}