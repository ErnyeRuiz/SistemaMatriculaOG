using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG
{
    public partial class PP_Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Entidades.Usuarios funcionario = (Entidades.Usuarios)Session["Usuario"];
                if (funcionario.IdRol != 4)
                {
                    Response.Redirect("Logout.aspx");
                }
                Negocio.SolicitudesRegistro config = new Negocio.SolicitudesRegistro();
                Entidades.Funcionarios func = config.TraerFuncionario(funcionario.Cedula);
                lblNombreFuncionario.Text = $"{func.NombreFuncionario} {func.ApellidosFuncionario}";
            }
            else {
                Response.Redirect("Logout.aspx");
            }
        }
    }
}