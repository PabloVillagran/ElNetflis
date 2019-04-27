using System;
using System.IO;
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
                int tmpId = 0;
                foreach(String line in lines)
                {
                    if (line.Contains("Genero:" + genero) || genero.Equals("TODO"))
                        peliculas.insertarRaiz(Pelicula.Parse(line, tmpId++));
                }
            }
            return peliculas;
        }

        public static void EliminarPelicula(String pathArchivo, string selectedPelicula)
        {
            string line = null;
            string newFile = "";
            using (StreamReader reader = new StreamReader(pathArchivo))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (String.Compare(line, selectedPelicula) == 0)
                        continue;
                    newFile += line + Environment.NewLine;
                }
            }
            File.WriteAllText(pathArchivo, newFile);
        }
    }
}