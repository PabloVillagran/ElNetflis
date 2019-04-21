using System;
using Estructuras.Generico;

namespace ElNetflis.Clases
{
    public class Pelicula : CarouselObject
    {
        public String Nombre { get; set; }
        public String Director { get; set; }
        public int Year { get; set; }
        public String Genero { get; set; }
        public String Descripcion { get; set; }
        public String PosterUrl { get; set; }

        internal static Pelicula Parse(string line)
        {
            Pelicula tmp = new Pelicula();
            String[] datos = line.Split('|');
            tmp.Genero = datos[0].Replace("Genero:", "");
            tmp.Nombre = datos[1].Replace("Nombre:", "");
            tmp.Director = datos[2].Replace("Director:", "");
            tmp.Year = Int32.Parse(datos[3].Replace("Year:",""));
            tmp.Descripcion = datos[4].Replace("Descripcion:","");
            tmp.PosterUrl = datos[5].Replace("PosterUrl:","");
            return tmp;
        }

        public override string ToString()
        {
            return "Genero:" + Genero +
                "|Nombre:" + Nombre +
                "|Director:" + Director +
                "|Year:" + Year +
                "|Descripcion:" + Descripcion +
                "|PosterUrl:" + PosterUrl;
        }

        public string ToCarouselItem()
        {
            return "<div class=\"col - md - 3\"><a href=\"#\" class=\"thumbnail\">"+
                        "< img src = \""+PosterUrl+"\" alt = \""+Nombre+"\" " +
                        "style = \"max-height: 222px;max-width: 150px;\" /></ a ></ div > ";
        }
    }
}