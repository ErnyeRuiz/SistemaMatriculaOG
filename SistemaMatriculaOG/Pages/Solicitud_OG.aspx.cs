using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Solicitud_OG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arreglo = new string[4];
            arreglo[0] = "Seleccione una opción de graduación";
            arreglo[1] = "Examen";
            arreglo[2] = "Practica";
            arreglo[3] = "Proyecto";
            drpOpcion.DataSource = arreglo;
            drpOpcion.DataBind();
        }
    }
}