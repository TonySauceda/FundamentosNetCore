using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase() => Id = Guid.NewGuid();
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}";
        }
    }
}