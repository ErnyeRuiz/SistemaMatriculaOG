using Entidades;
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
        private string SeleccioneOG = "Seleccione una opcion de graduación";
        Entidades.Estudiante estudianteActual;
        Entidades.Usuarios usuarioActual;
        protected void Page_Load(object sender, EventArgs e)
        {
                     
            if (!IsPostBack)
            {              
                CargarInformacionEstudiante();
                CargarOpcionesGraduacion();
            }

        }
        private void CargarOpcionesGraduacion()
        {
            drpOpcion.DataSource = null; drpOpcion.DataBind();
            List<string> drpDataSource = new List<string>();
            drpDataSource.Add(SeleccioneOG);

            try
            {
                var result = Negocio.SolicitudesGraduacion.CargarTiposOG();

                if (result != null)
                {
                    foreach (Entidades.TipoGraduacion tipo in result)
                    {
                        drpDataSource.Add(tipo.NombreTipoG);
                    }
                    drpOpcion.DataSource = drpDataSource;
                    drpOpcion.DataBind();            
                }
            }catch (Exception )
            {
                string scriptalerta =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                 $"toastr.error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
               
        }
        private void CargarInformacionEstudiante()
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    usuarioActual = (Usuarios)Session["Usuario"];
                    if (usuarioActual != null)
                    {
                        estudianteActual = Negocio.Estudiante.BuscarEstudiante(usuarioActual.Cedula);
                    }
                }

                if (estudianteActual!= null)
                {
                    txtCedula.Text = estudianteActual.CedulaEstudiante;
                    txtNombreApellidos.Text = estudianteActual.NombreEstudiante + " " + estudianteActual.Apellido1 + " " + estudianteActual.Apellido2;
                    txtCarrera.Text = estudianteActual.CarreraId.ToString();
                    txtCorreo.Text = estudianteActual.Correo;
                    txtNumero.Text = estudianteActual.NumeroTelefono.ToString();

                    ValidarEstudianteEnvioOG(estudianteActual);
                }
            }catch (Exception)
            {
                string scriptalerta =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                 $"toastr.error('¡Algo salió mal no se pudo cargar la informacion del estudiante!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
            
        }
        private void ValidarEstudianteEnvioOG(Entidades.Estudiante estudiante)
        {
            try
            {
                if (estudiante != null)
                {
                    if (Negocio.SolicitudesGraduacion.ValidarEstudianteEnvioOG(estudiante.CedulaEstudiante))
                    {
                        Button1.Enabled = false;
                        string scriptalerta =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        $"toastr.warning('¡Ya enviaste una solicitud de Opcion de graduacion!');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
                    }
                }
            }
            catch (Exception)
            {
                string scriptalerta =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                 $"toastr.error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpOpcion.Text == SeleccioneOG)
            {
                string scriptalerta =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('¡Debe seleccionar una opcion de graduación!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
            else
            {
                string scriptalerta =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.success('¡Envío de solicitud de opción de graduación exitoso! Revisaremos tu solicitud y te daremos respuesta por medio del correo que ingresaste ¡Gracias!')";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrSuccess", scriptalerta, true);
                //Guardar el registro
                EnviarSolicitudOG();
                LimpiarTXT();
                CargarOpcionesGraduacion();
                Button1.Enabled = false;
            }
        }
        protected void LimpiarTXT()
        {
            txtCedula.Text = "";
            txtNombreApellidos.Text = "";
            txtCorreo.Text = "";
            txtNumero.Text = "";
            txtCarrera.Text = "";
        }
        private void EnviarSolicitudOG()
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    usuarioActual = (Usuarios)Session["Usuario"];
                    if (usuarioActual != null)
                    {
                        estudianteActual = Negocio.Estudiante.BuscarEstudiante(usuarioActual.Cedula);
                    }
                }
                Negocio.SolicitudesGraduacion.AgregarSolicitudOG(estudianteActual.CedulaEstudiante, drpOpcion.Text);

            }
            catch (Exception)
            {
                string scriptalerta =
                   "toastr.options.closeButton = true;" +
                   "toastr.options.positionClass = 'toast-bottom-right';" +
                   $"toastr.error('¡Algo salió mal no se pudo enviar la solicitud!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
        }
    }
}