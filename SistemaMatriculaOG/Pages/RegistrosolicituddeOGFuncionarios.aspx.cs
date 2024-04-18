using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class RegistrosolicituddeOGFuncionarios : System.Web.UI.Page
    {
        // Instancia de la capa de negocios
        private Negocio.SolicitudGraduacionregistro _solicitudGraduacionregistro;
        protected void Page_Load(object sender, EventArgs e)
        {
            _solicitudGraduacionregistro = new Negocio.SolicitudGraduacionregistro();

            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Entidades.Usuarios user = (Entidades.Usuarios)Session["Usuario"];
                    if (user.IdRol != 4)
                    {
                        Response.Redirect("Logout.aspx");
                    }
                }
                else {
                    Response.Redirect("Logout.aspx");
                }

                // Cargar los tipos de graduación de la base de datos y configurar el DropDownList
                List<TipoGraduacion> tiposGraduacion = _solicitudGraduacionregistro.ObtenerTiposGraduacion();

                ddlOpcionGraduacion.DataSource = tiposGraduacion;
                ddlOpcionGraduacion.DataTextField = "NombreTipoG";
                ddlOpcionGraduacion.DataValueField = "IdTipoGraduacion";
                ddlOpcionGraduacion.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Entidades.Usuarios user = (Entidades.Usuarios)Session["Usuario"];
                if (user.IdRol != 4)
                {
                    Response.Redirect("Logout.aspx");
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }

            try
            {
                // Captura los datos del formulario
                string cedulaEstudiante = txtCedulaEstudiante.Text;
                string opcionGraduacion = ddlOpcionGraduacion.SelectedValue;

                // Llama a la capa de negocios para agregar la solicitud
                string resultado = _solicitudGraduacionregistro.AgregarSolicitud(cedulaEstudiante, opcionGraduacion);

                // Muestra el resultado al usuario
                lblMensaje.Text = resultado;
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales
                lblMensaje.Text = $"Error inesperado: {ex.Message}";
            }
        }

    }
}