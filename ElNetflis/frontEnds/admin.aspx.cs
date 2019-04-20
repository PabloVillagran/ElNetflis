using ElNetflis.Clases;
using Estructuras.ListaDoble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElNetflis.frontEnds
{
    public partial class admin : System.Web.UI.Page
    {
        private String ArchivoPeliculas = HttpRuntime.AppDomainAppPath+"peliculas.txt";

        private ListaDoble PeliculasDrama;
        private ListaDoble PeliculasAccion;
        private ListaDoble PeliculasNinos;

        protected void Page_Load(object sender, EventArgs e)
        {
            PeliculasDrama = Utils.CargarPeliculas(ArchivoPeliculas, "Drama");
            PeliculasAccion = Utils.CargarPeliculas(ArchivoPeliculas, "AccAventura");
            PeliculasNinos = Utils.CargarPeliculas(ArchivoPeliculas, "Children");
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.Nombre = tbNombre.Text;
            pelicula.Director = tbAutor.Text;
            pelicula.Descripcion = taDescripcion.Value;
            pelicula.Year = Int32.Parse(tbYear.Text);
            pelicula.PosterUrl = tbPosterUrl.Text;
            pelicula.Genero = ddGenero.SelectedValue;

            GuardarPelicula(pelicula);

            Clear();
        }

        private bool GuardarPelicula(Pelicula pelicula)
        {
            switch (pelicula.Genero)
            {
                case "Drama":
                    if (PeliculasDrama.Contains(pelicula)) return false;
                    else
                    {
                        PeliculasDrama.insertarRaiz(pelicula);
                        break;
                    }
                case "Children":
                    if (PeliculasNinos.Contains(pelicula)) return false;
                    else
                    {
                        PeliculasNinos.insertarRaiz(pelicula);
                        break;
                    }
                case "AccAventura":
                    if (PeliculasAccion.Contains(pelicula)) return false;
                    else
                    {
                        PeliculasAccion.insertarRaiz(pelicula);
                        break;
                    }
            }
            using (System.IO.StreamWriter archivo = new System.IO.StreamWriter(ArchivoPeliculas, true))
            {
                archivo.WriteLine(pelicula.ToString());
            }
            return true;
        }

        private void Clear()
        {
            tbNombre.Text = "";
            tbAutor.Text = "";
            taDescripcion.Value = "";
            tbYear.Text="";
            tbPosterUrl.Text="";
            ddGenero.SelectedValue="Drama";
        }

        protected void bEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void ddCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDoble tmp = null;
            switch (ddCategoria.SelectedValue)
            {
                case "Children":
                    tmp = PeliculasNinos;
                    break;
                case "Drama":
                    tmp = PeliculasDrama;
                    break;
                case "AccAventura":
                    tmp = PeliculasAccion;
                    break;
            }
            if (tmp != null)
            {
                foreach(Pelicula pelicula in tmp)
                {
                    Console.WriteLine(pelicula);
                }
            }
        }
    }
}
