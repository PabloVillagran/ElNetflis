using ElNetflis.Clases;
using Estructuras.Cola;
using Estructuras.ListaDoble;
using Estructuras.Pila;
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

        private static Pila ContinuarViendo;
        private static Cola MiListaPersonal;

        protected void Page_Load(object sender, EventArgs e)
        {
            PeliculasDrama = Utils.CargarPeliculas(ArchivoPeliculas, "Drama");
            PeliculasAccion = Utils.CargarPeliculas(ArchivoPeliculas, "AccAventura");
            PeliculasNinos = Utils.CargarPeliculas(ArchivoPeliculas, "Children");
            //Mi Lista tipo Cola
            MiListaPersonal = (Cola)HttpContext.Current.Session["ListaPersonal"];
            if (MiListaPersonal == null)
            {
                
            }
            //Continuar Viendo tipo pila
            ContinuarViendo = (Pila)HttpContext.Current.Session["ContiuarViendo"];
            if(ContinuarViendo == null)
            {
                ContinuarViendo = new Pila();
                HttpContext.Current.Session["ContinuarViendo"] = ContinuarViendo;

                continuarItem.Text = "<div class=\"col-md-6\"><a id=\"linkContinuar\" href=\"#\" class=\"thumbnail\" onclick=\"pilaVacia()\">" +
                    "<img id=\"thumbContinuar\" src=\"#\" alt=\"Image\" style=\"height: 222px; width: 150px;\"/>" +
                    "</a></div><button type=\"button\" id=\"buttonContinuar\" class=\"btn btn-primary col-md-6\" onclick=\"javascript:pilaVacia();\">Continuar</button>";
            }
            else
            {
                Pelicula tmp = ((Pelicula)ContinuarViendo.Peek());
                continuarItem.Text = "<div class=\"col-md-6\">" +
                    tmp.ToThumbNail("Continuar")
                    + "</div>"
                    + "<button type=\"button\" id=\"Continuar\" class=\"btn btn-primary col-md-6\" onclick=\"fillAndShowModal('" + tmp.Nombre + "','" + tmp.Descripcion + "','" + tmp.PosterUrl + "')\">Continuar</button>";
            }

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
            for (int i = 0; i < indicatorsQuantity; i++)
            {
                indicators += "<li data-target=\"#carAccion\" data-slide-to=\"" + i + "\" " + (i == 0 ? "class=\"active\"" : "") + "></li>";
            }
            indicators += "</ol>";
            return indicators;
        }

        protected void Continuar_Click(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession =true)]
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

        [WebMethod(EnableSession = true)]
        public static RetornoContinuarLuego ContinuarLuego()
        {
            ContinuarViendo = (Pila)HttpContext.Current.Session["ContinuarViendo"];
            ContinuarViendo.Push(peliculaActiva);
            RetornoContinuarLuego retorno = new RetornoContinuarLuego();
            retorno.Cima = (Pelicula)ContinuarViendo.Peek();
            retorno.Mensaje = "Se ha añadido la película " + retorno.Cima.Nombre + " a la pila de reproducción.";
            peliculaActiva = null;
            HttpContext.Current.Session["ContinuarViendo"] = ContinuarViendo;
            return retorno;
        }
    }
}