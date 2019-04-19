using ElNetflis.Clases;
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

        protected void Page_Load(object sender, EventArgs e)
        {

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

        private void GuardarPelicula(Pelicula pelicula)
        {
            using (System.IO.StreamWriter archivo = new System.IO.StreamWriter(ArchivoPeliculas, true))
            {
                archivo.WriteLine(pelicula.ToString());
            }
            
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
    }
}