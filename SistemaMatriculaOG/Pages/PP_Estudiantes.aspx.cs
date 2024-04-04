using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace SistemaMatriculaOG.Pages
{
    public partial class PP_Estudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (await Negocio.SolicitudesGraduacion.CargarTiposOG())
            //{
            //    lblTexto.Text = "carga correcta";
            //}
            //else {
            //    lblTexto.Text = "Carga incorrecta";
            //}
            if (Session["Mensaje"] != null)
            {
                //Mensaje en pantalla
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.success('{Convert.ToString(Session["Mensaje"])}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                Session["Mensaje"] = null;
            }

        }
    }
}