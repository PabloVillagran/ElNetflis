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
            carAccionIndicators.Text = GetIndicators("AccAventura");
            
        }

        private string GetIndicators(string v)
        {
            String indicators = "<ol class=\"carousel - indicators\">";
            ListaDoble tmp = null;
            switch (v)
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
                indicators += "<li data-target=\"#carAccion\" data-slide-to=\""+i+"\" "+(i==0?"class=\"active\">":"")+"</li>";
            }
            indicators += "</ol>";
            return indicators;
        }

        protected void Continuar_Click(object sender, EventArgs e)
        {

        }
    }
}