﻿using System;
using Estructuras.Generico;

namespace ElNetflis.Clases
{
    public class Pelicula : CarouselObject
    {
        public int TmpId { get; set; }
        public String Nombre { get; set; }
        public String Director { get; set; }
        public int Year { get; set; }
        public String Genero { get; set; }
        public String Descripcion { get; set; }
        public String PosterUrl { get; set; }

        public static Pelicula Parse(string line)
        {
            Pelicula tmp = new Pelicula();
            String[] datos = line.Split('|');
            tmp.Genero = datos[0].Replace("Genero:", "");
            tmp.Nombre = datos[1].Replace("Nombre:", "").Replace("'", "");
            tmp.Director = datos[2].Replace("Director:", "").Replace("'", "");
            tmp.Year = Int32.Parse(datos[3].Replace("Year:",""));
            tmp.Descripcion = datos[4].Replace("Descripcion:","").Replace("'","");
            tmp.PosterUrl = datos[5].Replace("PosterUrl:","");
            return tmp;
        }

        public static Pelicula Parse(string line, int tmpId)
        {
            Pelicula tmp = Parse(line);
            tmp.TmpId = tmpId;
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
            return "<div class=\"col-md-3\">" +
                "<a href=\"#\" onclick=\"getPelicula("+TmpId+", '"+Genero+"');\" class=\"thumbnail\">" +
                        "<img src=\""+PosterUrl+"\" alt=\""+Nombre+"\" title=\""+Nombre+"\" " +
                        "style=\"height: 222px; width: 150px;\"/></a></div>";
        }

        internal string ToThumbNail(String parent)
        {
            return "" +
                "<a href=\"#\" id=\"link"+parent+ "\" class=\"thumbnail\" onclick=\"fillAndShowModal('"+Nombre+"','"+Descripcion+"','"+PosterUrl+"')\">" +
                        "<img id=\"thumb"+parent+"\" src=\"" + PosterUrl + "\" alt=\"" + Nombre + "\" title=\"" + Nombre + "\" " +
                        "style=\"height: 222px; width: 150px;\"/></a>";
        }
    }
}