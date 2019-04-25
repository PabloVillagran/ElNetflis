using System;
using System.Collections.Generic;
using System.Text;

namespace Estructuras.Pila
{
    public class Pila
    {
        private Nodo Cima { get; set; }

        public Pila()
        {
            Cima = null;
        }

        public void Push(object dato)
        {
            Nodo tmp = new Nodo(dato);
            tmp.Siguiente = Cima;
            Cima = tmp;
        }

        public object Pop()
        {
            Nodo tmp = Cima;
            if (tmp != null)
            {
                Cima = Cima.Siguiente;
                tmp.Siguiente = null;
                object dato = tmp.Dato;
                tmp = null;
                return dato;
            }
            else return null;
        }

        public object Peek()
        {
            return (Cima != null) ? Cima.Dato: null ;
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
