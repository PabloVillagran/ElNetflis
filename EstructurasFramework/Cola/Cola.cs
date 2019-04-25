using System;
using System.Collections.Generic;
using System.Text;

namespace Estructuras.Cola
{
    public class Cola
    {
        private Nodo Inicio { get; set; }
        private Nodo Fin { get; set; }

        public Cola()
        {
            Inicio = null;
            Fin = null;
        }

        public void Agregar(object dato)
        {
            Nodo tmp = new Nodo(dato);
            if (ColaVacia())
            {
                Inicio = tmp;
            }
            else {
                Fin.Siguiente = tmp;
            }
            Fin = tmp;
        }

        public object Quitar()
        {
            object tmp = null;
            if (!ColaVacia())
            {
                tmp = Inicio.Dato;
                Inicio = Inicio.Siguiente;
            }
            return tmp;
        }

        public object VerInicio()
        {
            if (Inicio != null)
                return Inicio.Dato;
            else
                return null;
        }

        public object VerFin()
        {
            if (Fin != null)
                return Fin.Dato;
            else
                return null;
        }

        public bool ColaVacia()
        {
            return Inicio == null;
        }
    }

    public class Nodo
    {
        public object Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo(object dato)
        {
            this.Dato = dato;
        }
    }
}
