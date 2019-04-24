using ElNetflis.Clases;

using Estructuras.ListaDoble;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace ElNetflis.frontEnds
{
    public partial class index : System.Web.UI.Page
    {
        private String ArchivoPeliculas = HttpRuntime.AppDomainAppPath + "peliculas.txt";
        private String ArchivoUsuario = HttpRuntime.AppDomainAppPath + "usuario.txt";

        private static ListaDoble PeliculasDrama;
        private static ListaDoble PeliculasAccion;
        private static ListaDoble PeliculasNinos;

        private static Pelicula peliculaActiva;

        protected void Page_Load(object sender, EventArgs e)
        {
            PeliculasDrama = Utils.CargarPeliculas(ArchivoPeliculas, "Drama");
            PeliculasAccion = Utils.CargarPeliculas(ArchivoPeliculas, "AccAventura");
            PeliculasNinos = Utils.CargarPeliculas(ArchivoPeliculas, "Children");
            //Mi Lista tipo Cola

            //Continuar Viendo tipo pila

            LlenarContenido();
        }

        private void LlenarContenido()
        {
            carAccionIndicators.Text = GetIndicators("AccAventura");
            carAccionImages.Text = PeliculasAccion.ToCarouselItems();
            carDramaIndicators.Text = GetIndicators("Drama");
            carDramaImages.Text = PeliculasDrama.ToCarouselItems();
            carChildIndicators.Text = GetIndicators("Children");
            carChildImages.Text = PeliculasNinos.ToCarouselItems();
        }

        private string GetIndicators(string categoria)
        {
            String indicators = "<ol class=\"carousel-indicators\">";
            ListaDoble tmp = null;
            switch (categoria)
            {
                case "AccAventura":
                    tmp = PeliculasAccion;
                    break;
                case "Drama":
                    tmp = PeliculasDrama;
                    break;
                case "Children":
                    tmp = PeliculasNinos;
                    break;
                default:
                    return null;
            }
            int indicatorsQuantity = (int)Math.Ceiling((double)tmp.Size / 4);
            for(int i = 0; i < indicatorsQuantity; i++)
            {
                indicators += "<li data-target=\"#carAccion\" data-slide-to=\""+i+"\" "+(i==0?"class=\"active\"":"")+"></li>";
            }
            indicators += "</ol>";
            return indicators;
        }

        protected void Continuar_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Pelicula GetPeliculaById(int TempId, String Genero)
        {
            ListaDoble tmp = null;
            switch (Genero)
            {
                case "AccAventura":
                    tmp = PeliculasAccion;
                    break;
                case "Drama":
                    tmp = PeliculasDrama;
                    break;
                case "Children":
                    tmp = PeliculasNinos;
                    break;
                default:
                    return null;
            }
            peliculaActiva = (Pelicula)tmp.GetByTmpId(TempId);
            return peliculaActiva;
        }

        [WebMethod]
        public static Pelicula VerPelicula(int TempId, String Genero)
        {
            
        }
    }
}