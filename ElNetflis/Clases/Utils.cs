using System;
using Estructuras.ListaDoble;

namespace ElNetflis.Clases
{
    public class Utils
    {
        public static ListaDoble CargarPeliculas(String pathArchivo, String genero)
        {
            ListaDoble peliculas = new ListaDoble();
            if (System.IO.File.Exists(pathArchivo))
            {
                string[] lines = System.IO.File.ReadAllLines(pathArchivo);
                foreach(String line in lines)
                {
                    if (line.Contains("Genero:" + genero))
                        peliculas.insertarRaiz(Pelicula.Parse(line));
                }
            }
            return peliculas;
        }

    }
}