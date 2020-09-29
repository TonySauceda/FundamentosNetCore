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
    }
}