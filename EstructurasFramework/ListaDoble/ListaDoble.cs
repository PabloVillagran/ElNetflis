
namespace Estructuras.ListaDoble
{
    public class ListaDoble
    {
        public Nodo Raiz { get; private set; }

        public ListaDoble()
        {
            Raiz = null;
        }

        public void insertarRaiz(object dato)
        {
            Nodo tmp = new Nodo(dato);
            tmp.Siguiente = Raiz;
            if (Raiz == null)
                Raiz.Anterior = tmp;
            Raiz = tmp;
        }

        public void insertarUltimo(object dato)
        {
            Nodo tmp = new Nodo(dato);
            //TODO
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
            }
        }

        public string Print2Json()
        {
            return null;
        }

        public object buscar()
        {
            return null;
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