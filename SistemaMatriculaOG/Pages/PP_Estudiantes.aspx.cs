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
            if (!IsPostBack) {
                if (Session["Usuario"] != null)
                {
                    Entidades.Usuarios estudiante = (Entidades.Usuarios)Session["Usuario"];
                    if (estudiante.IdRol != 1)
                    {
                        Response.Redirect("Logout.aspx");
                    }
                    Negocio.SolicitudesRegistro config = new Negocio.SolicitudesRegistro();
                    Entidades.Estudiante Estudiante = config.TraerEstudiante(estudiante.Cedula);
                    lblNombreEstudiante.Text = $"{Estudiante.NombreEstudiante} {Estudiante.Apellido1} {Estudiante.Apellido2}";
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }

            }
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