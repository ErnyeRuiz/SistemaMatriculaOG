using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Responder_SolicitudesOG : System.Web.UI.Page
    {
        List<Carreras> carreras = new List<Carreras>();
        List<VistaSolicitudesPendientes> listaSolicitudesPendientes = new List<VistaSolicitudesPendientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios user = (Usuarios)Session["Usuario"];

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarCarreras();
                CargarSolicitudes();
            }
        }
        private void CargarSolicitudes()
        {
            try
            {
                listaSolicitudesPendientes = Negocio.SolicitudesGraduacion.VerSolicitudesOGPendientes();

             rptSolicitudesOG.DataSource = listaSolicitudesPendientes;

                rptSolicitudesOG.DataBind();
            }
            catch (Exception)
            {
                string scriptalerta =
                                              "toastr.options.closeButton = true;" +
                                              "toastr.options.positionClass = 'toast-bottom-right';" +
                                              $"toastr.Error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
           
        }
        private void CargarCarreras()
        {
            try
            {
                carreras = Negocio.SolicitudesGraduacion.VerCarreras();

                drpCarrera.Items.Add(new ListItem("Todas"));

                if (carreras.Count > 0)
                {
                    foreach (var carrera in carreras)
                    {
                        ListItem listItem = new ListItem(carrera._NombreCarrera);
                        drpCarrera.Items.Add(listItem);
                    }
                }
            }
            catch (Exception)
            {
                string scriptalerta =
                              "toastr.options.closeButton = true;" +
                              "toastr.options.positionClass = 'toast-bottom-right';" +
                              $"toastr.Error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true); ;
            }
            
        }
        //Evento de seleccion de carrera 
        protected void drpCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaSolicitudesPendientes = Negocio.SolicitudesGraduacion.VerSolicitudesOGPendientes();
                if (drpCarrera.Text != "Todas")
                {
                    var filtroCarrera = listaSolicitudesPendientes.Where(solicitud => solicitud.Carrera == drpCarrera.Text)
                        .ToList();
                    rptSolicitudesOG.DataSource = filtroCarrera;
                    rptSolicitudesOG.DataBind();
                }
                else
                {
                    rptSolicitudesOG.DataSource = listaSolicitudesPendientes;
                    rptSolicitudesOG.DataBind();
                }
            }
            catch (Exception)
            {
                string scriptalerta =
                              "toastr.options.closeButton = true;" +
                              "toastr.options.positionClass = 'toast-bottom-right';" +
                              $"toastr.Error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
           

        }
        protected void rptSolicitudesOG_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#miModal').modal('show');", true);
                CargarSolicitudModal(e.CommandArgument.ToString());
            }
        }
        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#modalMotivo').modal('show');", true);

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtMotivo.Text.Length == 0)
            {
                string scriptalerta =
              "toastr.options.closeButton = true;" +
              "toastr.options.positionClass = 'toast-bottom-right';" +
              $"toastr.warning('¡Debe ingresar un motivo!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
            }
            else
            {
                try
                {
                    Usuarios user = (Usuarios)Session["Usuario"];
                    Negocio.SolicitudesGraduacion.CambiarEstadoSolicitudOG(Convert.ToInt16(lblIdSolicitud.Text), txtMotivo.Text, user.Cedula);
                    CargarSolicitudes();
                    string scriptalerta =
                       "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                       $"toastr.success('¡Solicitud Rechazada correctamente!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrSuccess", scriptalerta, true);
                }
                catch (Exception)
                {
                    string scriptalerta =
                              "toastr.options.closeButton = true;" +
                              "toastr.options.positionClass = 'toast-bottom-right';" +
                              $"toastr.Error('¡Algo salió mal!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }
               
            }
        }

        private void CargarSolicitudModal(string idSolicitud)
        {
            try
            {
                listaSolicitudesPendientes = Negocio.SolicitudesGraduacion.VerSolicitudesOGPendientes();
                var solicitud = listaSolicitudesPendientes.FirstOrDefault(so =>
                so.IdSolicitud == Convert.ToInt16(idSolicitud));

                if (solicitud != null)
                {
                    lblIdSolicitud.Text = solicitud.IdSolicitud.ToString();
                    lblNombreEstudiante.Text = solicitud.Nombre + " " + solicitud.Apellidos;
                    lblCedula.Text = solicitud.Cedula;
                    lblCorreo.Text = solicitud.Correo;
                    lblTelefono.Text = solicitud.NumeroTelefono;
                    lblCarrera.Text = solicitud.Carrera;
                    lblTipo.Text = solicitud.Tipo;
                    lblFechaHoraEnvio.Text = solicitud.Fecha.ToString();
                    lblEstadoSolicitud.Text = solicitud.Estado;
                }
            }
            catch (Exception)
            {
                string scriptalerta =
                              "toastr.options.closeButton = true;" +
                              "toastr.options.positionClass = 'toast-bottom-right';" +
                              $"toastr.Error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
           

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios user = (Usuarios)Session["Usuario"];

                Negocio.SolicitudesGraduacion.CambiarEstadoSolicitudOG(Convert.ToInt16(lblIdSolicitud.Text), null, user.Cedula);
                CargarSolicitudes();
                string scriptalerta =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.success('¡Solicitud aprobada correctamente!')";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrSuccess", scriptalerta, true);

            }
            catch (Exception)
            {
                string scriptalerta =
                              "toastr.options.closeButton = true;" +
                              "toastr.options.positionClass = 'toast-bottom-right';" +
                              $"toastr.Error('¡Algo salió mal!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }

        }       
    }
}