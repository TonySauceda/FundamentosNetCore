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
            DibujarLiena(titulo.Length * 2);
            WriteLine($"{"".PadRight((int)Math.Floor((decimal)titulo.Length / 2), ' ')}{titulo.ToUpper()}");
            DibujarLiena(titulo.Length * 2);
        }
    }
}