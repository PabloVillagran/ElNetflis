using ElNetflis.Clases;
using Estructuras.ListaDoble;
using System;
using System.Web;

namespace ElNetflis.frontEnds
{
    public partial class index : System.Web.UI.Page
    {
        private String ArchivoPeliculas = HttpRuntime.AppDomainAppPath + "peliculas.txt";
        private String ArchivoUsuario = HttpRuntime.AppDomainAppPath + "usuario.txt";

        private ListaDoble PeliculasDrama;
        private ListaDoble PeliculasAccion;
        private ListaDoble PeliculasNinos;

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
            foreach(Pelicula pelicula in PeliculasDrama)
            {

            }
            foreach(Pelicula pelicula in PeliculasAccion)
            {

            }
            foreach(Pelicula pelicula in PeliculasNinos)
            {

            }
        }

        protected void Continuar_Click(object sender, EventArgs e)
        {

        }
    }
}