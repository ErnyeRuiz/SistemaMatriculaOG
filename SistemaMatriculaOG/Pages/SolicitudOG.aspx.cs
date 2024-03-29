using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class SolicitudOG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arreglo = new string[3];
            arreglo[0] = "Examen";
            arreglo[1] = "Practica";
            arreglo[2] = "Proyecto";
            drpOG.DataSource = arreglo;
            drpOG.DataBind();
        }
    }
}