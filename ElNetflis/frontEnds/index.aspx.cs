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

        private static ListaDoble PeliculasDrama;
        private static ListaDoble PeliculasAccion;
        private static ListaDoble PeliculasNinos;

        private static ListaDoble Todas;
        private static ListaDoble Buscadas;

        private static Pelicula peliculaActiva;

        private static Pila ContinuarViendo;
        private static Cola MiListaPersonal;

        protected void Page_Load(object sender, EventArgs e)
        {
            PeliculasDrama = Utils.CargarPeliculas(ArchivoPeliculas, "Drama");
            PeliculasAccion = Utils.CargarPeliculas(ArchivoPeliculas, "AccAventura");
            PeliculasNinos = Utils.CargarPeliculas(ArchivoPeliculas, "Children");

            Todas = new ListaDoble();
            Todas.AgregarLista(PeliculasDrama);
            Todas.AgregarLista(PeliculasAccion);
            Todas.AgregarLista(PeliculasNinos);

            Buscadas = new ListaDoble();
            //Mi Lista tipo Cola
            //MiListaPersonal = (Cola)HttpContext.Current.Session["ListaPersonal"];
            //if (MiListaPersonal == null)
            {
                MiListaPersonal = new Cola();
                HttpContext.Current.Session["ListaPersonal"] = MiListaPersonal;

                miListaItem.Text = "<div class=\"col-md-6\"><a id=\"linkLista\" href=\"#\" class=\"thumbnail\" onclick=\"pilaVacia()\">" +
                    "<img id=\"thumbLista\" src=\"#\" style=\"height: 222px; width: 150px;\"/>" +
                    "</a></div><button type=\"button\" id=\"buttonLista\" class=\"btn btn-primary col-md-6\" onclick=\"javascript:pilaVacia();\">Ver película en cola</button>";
            }
            //else
            //{
            //Pelicula tmp = ((Pelicula)MiListaPersonal.VerInicio());
            //    miListaItem.Text = "<div class=\"col-md-6\">" +
            //        tmp.ToThumbNail("Continuar")
            //        + "</div>"
            //        + "<button type=\"button\" id=\"Continuar\" class=\"btn btn-primary col-md-6\" onclick=\"fillAndShowModal('" + tmp.Nombre + "','" + tmp.Descripcion + "','" + tmp.PosterUrl + "')\">Continuar</button>";
            // }
            //Continuar Viendo tipo pila
            ContinuarViendo = (Pila)HttpContext.Current.Session["ContiuarViendo"];
            if(ContinuarViendo == null)
            {
                ContinuarViendo = new Pila();
                HttpContext.Current.Session["ContinuarViendo"] = ContinuarViendo;

                continuarItem.Text = "<div class=\"col-md-6\"><a id=\"linkContinuar\" href=\"#\" class=\"thumbnail\" onclick=\"pilaVacia()\">" +
                    "<img id=\"thumbContinuar\" src=\"#\" style=\"height: 222px; width: 150px;\"/>" +
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

        [WebMethod]
        public static RetornoContinuarLuego PopContinuar()
        {
            RetornoContinuarLuego retorno = new RetornoContinuarLuego();
            Pelicula anterior = (Pelicula)ContinuarViendo.Pop();
            Pelicula siguiente = (Pelicula)ContinuarViendo.Peek();
            if (siguiente != null)
            {
                retorno.Mensaje = ("Se ha finalizado de ver la pelicula "+anterior.Nombre+", la siguiente en la lista es "+siguiente.Nombre+".");
                retorno.Cima = siguiente;
            }
            else
            {
                retorno.Mensaje = "Has terminado de ver todas las películas que tenias pendientes.";
            }
            return retorno;
        }

        [WebMethod]
        public static RetornoContinuarLuego AgregarLista()
        {
            RetornoContinuarLuego retorno = new RetornoContinuarLuego();
            MiListaPersonal.Agregar(peliculaActiva);
            retorno.Cima = (Pelicula)MiListaPersonal.VerInicio();
            retorno.Mensaje = "Se ha añadido la película " + peliculaActiva.Nombre + " a tu cola de reproducción.";
            peliculaActiva = null;
            HttpContext.Current.Session["ListaPersonal"] = MiListaPersonal;
            return retorno;
        }

        [WebMethod]
        public static RetornoContinuarLuego SacarCola()
        {
            RetornoContinuarLuego retorno = new RetornoContinuarLuego();
            Pelicula anterior = (Pelicula)MiListaPersonal.Quitar();
            Pelicula siguiente = (Pelicula)MiListaPersonal.VerInicio();
            if (siguiente != null)
            {
                retorno.Mensaje = ("Se ha finalizado de ver la pelicula " + anterior.Nombre + ", la siguiente en la cola es " + siguiente.Nombre + ".");
                retorno.Cima = siguiente;
            }
            else
            {
                retorno.Mensaje = "Has terminado de ver todas las películas que tenias en tu lista personal.";
            }
            return retorno;
        }

        [WebMethod]
        public static ListaDoble Buscar(String buscado)
        {
            buscado = buscado.ToLower();
            Todas.LimiteBusqueda = 3;
            return Todas.BuscarSimilares(buscado);
        }
    }
}