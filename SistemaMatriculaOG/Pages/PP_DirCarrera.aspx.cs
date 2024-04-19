using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class PP_DirCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Entidades.Usuarios Dir = (Entidades.Usuarios)Session["Usuario"];
                    if (Dir.IdRol != 3)
                    {
                        Response.Redirect("Logout.aspx");
                    }
                    Negocio.SolicitudgraduacionAprobadas neg=new Negocio.SolicitudgraduacionAprobadas();
                    Entidades.DirectoresCarrera director = neg.TraerDirector(Dir.Cedula);
                    lblNombre.Text = $"{director._NombreDirectorCarrera} {director._ApellidosDirectorCarrera}";
                    List<Entidades.Carreras> lst = neg.TraerCarrera();
                    lblCarrera.Text = lst.Find(C => C._IdCarrera == Convert.ToInt32(director._CarreraDirectorC))._NombreCarrera;
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }

            }
        }
    }
}