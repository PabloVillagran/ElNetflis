
using Estructuras.Generico;
using System;
using System.Collections;

namespace Estructuras.ListaDoble
{
    public class ListaDoble : IEnumerator, IEnumerable
    {
        public Nodo Raiz { get; private set; }
        public Nodo Ultimo { get; private set; }

        private Nodo enumerador = new Nodo(null);
        public int Size { get; set;}

        public int LimiteBusqueda { get; set; }

        public ListaDoble()
        {
            Raiz = null;
            enumerador.Siguiente = Raiz;
            Size = 0;
        }

        public bool Contains(object dato)
        {
            Nodo tmp = Raiz;
            while(tmp != null)
            {
                if(tmp.Dato.ToString() == dato.ToString())
                {
                    return true;
                }
                tmp = tmp.Siguiente;
            }
            return false;
        }

        public void insertarRaiz(object dato)
        {
            Nodo tmp = new Nodo(dato);
            tmp.Siguiente = Raiz;
            if (Raiz != null)
                Raiz.Anterior = tmp;
            Raiz = tmp;
            if (Ultimo == null)
                Ultimo = Raiz;
            if(enumerador!=null)
                enumerador.Siguiente = Raiz;
            Size++;
        }

        public void AgregarLista(ListaDoble lista)
        {
            ListaDoble tmp = Clonar(lista);
            tmp.Raiz = lista.Raiz;
            tmp.Ultimo = lista.Ultimo;
            if (Raiz == null)
            {
                Raiz = tmp.Raiz;
                Ultimo = tmp.Ultimo;
            }
            else
            {
                tmp.Raiz.Anterior = Ultimo;
                Ultimo.Siguiente = tmp.Raiz;
                Ultimo = tmp.Ultimo;
            }
        }

        private ListaDoble Clonar(ListaDoble lista)
        {
            Nodo tmp = lista.Raiz;
            ListaDoble resultado = new ListaDoble();
            while (tmp != null)
            {
                resultado.insertarRaiz(tmp);
                tmp = tmp.Siguiente;
            }
            return resultado;
        }

        public void eliminar(object dato)
        {
            Nodo tmp = Raiz;
            bool encontrado = false;
            while(tmp!=null && !encontrado) //BUSCA EL DATO POR TODA LA LISTA
            {
                encontrado = tmp.Dato.ToString() == dato.ToString();
                if (!encontrado)
                    tmp = tmp.Siguiente;
            }

            if(tmp != null) //Si encontró el dato
            {
                if(tmp == Raiz)
                {
                    Raiz = tmp.Siguiente;
                    if (tmp.Siguiente != null)
                        tmp.Siguiente.Anterior = null; //elimina la conexión a el nodo actual desde el nodo siguiente.
                }
                else if(tmp.Siguiente != null) //Existen más nodos en la lista
                {
                    tmp.Siguiente.Anterior = tmp.Anterior; //Redirige el apuntador del nodo Anterior al Siguiente del nodo actual
                    tmp.Anterior.Siguiente = tmp.Siguiente; //Redirige el apuntador del nodo Siguiente al Anterior del nodo actual
                }
                else
                {
                    tmp.Anterior.Siguiente = null;
                }
                tmp = null; //Elimina el nodo
                if(enumerador!=null)
                    enumerador.Siguiente = Raiz;
                Size--;
            }
        }

        public bool IsEmpty()
        {
            return Raiz == null;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            enumerador = enumerador.Siguiente;
            return enumerador != null;
        }

        //IEnumerable
        public void Reset()
        {
            enumerador = new Nodo(null);
            enumerador.Siguiente = Raiz;
        }

        //IEnumerable
        public object Current
        {
            get {return enumerador.Dato;}
        }

        public string ToCarouselItems()
        {
            Nodo tmp = Raiz;
            int pos = 1;
            int limit = 4;
            string item = "<div class=\"item active\">";
            while(tmp != null)
            {
                if(tmp.Dato is CarouselObject)
                {
                    item += ((CarouselObject)tmp.Dato).ToCarouselItem();
                    tmp = tmp.Siguiente;
                    if(pos++ >= limit)
                    {
                        item += "</div>";
                        item += "<div class=\"item\">";
                        limit += 4;
                    }
                }
                else
                {
                    throw new NotImplementedException("El tipo de dato no es soportado por este método. Se esperaba CarouselObject.");
                }
            }
            item += "</div>";
            return item;
        }

        public object GetByTmpId(int tmpId)
        {
            Nodo tmp = Raiz;
            while(tmp!=null)
            {
                if (tmp.Dato is CarouselObject)
                {
                    if (tmpId == ((CarouselObject)tmp.Dato).TmpId)
                        return tmp.Dato;
                }
                tmp = tmp.Siguiente;
            }
            return null;
        }

        public ListaDoble BuscarSimilares(string dato)
        {
            ListaDoble resultados = new ListaDoble();
            Nodo tmp = Raiz;
            int contador = 0;
            while (tmp != null)
            {
                if(tmp.Dato is CarouselObject)
                {
                    if (((CarouselObject)tmp.Dato).Nombre.ToLower().Contains(dato))
                    {
                        resultados.insertarRaiz(tmp.Dato);
                        contador++;
                    }
                }
                else
                {
                    throw new NotImplementedException("Se esperaba un objeto de tipo CarouselObject.");
                }

                //Iterador
                if (contador < LimiteBusqueda)
                    tmp = tmp.Siguiente;
                else
                    tmp = null;
                
            }
            return resultados;
        }
    }

    public class Nodo
    {
        public object Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo(object dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
            this.Anterior = null;
        }
    }
}