using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Responder_Registro : System.Web.UI.Page
    {
        Negocio.SolicitudesRegistro solicitudes= new Negocio.SolicitudesRegistro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstSolicitudes.Items.Add("Seleccione una solicitud");
                if (solicitudes.TraerSolicitudesPendientes().Count>0) {
                    foreach (Entidades.SolicitudesRegistro S in solicitudes.TraerSolicitudesPendientes()) {
                        lstSolicitudes.Items.Add($"{S.IdsolicitudRegistro}-{S.CedulaEstudiante}-{S.IdEstado}");
                    }
                }
                else
                {
                    string scriptalerta =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.warning('¡No hay solicitudes de registro pendientes!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }
                
            }

            if (Session["Mensaje"]!=null) {
                string[] mensaje = Session["Mensaje"].ToString().Split(';');
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.{mensaje[0]}('{mensaje[1]}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                Session["Mensaje"] = null;
            }

        }

        protected void lstSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lstSolicitudes.SelectedValue.Equals("Seleccione una solicitud")) {
                Contenedor.Visible = true;
                string[] SolicitudSeleccionada = lstSolicitudes.SelectedValue.Split('-');

                //Cargar datos del estudiante
                Entidades.Estudiante estudiante = solicitudes.TraerEstudiante(SolicitudSeleccionada[1]);
                Dato1.Text =estudiante.CedulaEstudiante;
                Dato2.Text =$"{estudiante.NombreEstudiante} {estudiante.Apellido1} {estudiante.Apellido2}";
                Dato3.Text = estudiante.Nacionalidad;
                Dato4.Text = estudiante.Correo;
                Dato5.Text = estudiante.NumeroTelefono;
                Dato6.Text = estudiante.FechaNacimiento.ToShortDateString();
                Dato7.Text = estudiante.CarreraId;


                //Cargar datos de la solicitud
                string[] SolicitudR  = solicitudes.TraerSolicitudRegistro(Convert.ToInt32(SolicitudSeleccionada[0])).Split(';');

                DateTime FechaSolicitud = DateTime.Parse(SolicitudR[0]);
                DatoS1.Text = FechaSolicitud.ToShortDateString();
                DatoS2.Text = FechaSolicitud.ToString("hh:mm tt");
                DatoS3.Text = SolicitudR[1];


            }
            else {
                Contenedor.Visible = false;
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            if (!lstSolicitudes.SelectedValue.Equals("Seleccione una solicitud"))
            {
                //Cargar informacion
                string[] SolicitudSeleccionada = lstSolicitudes.SelectedValue.Split('-');
                Entidades.Usuarios Funcionario= new Entidades.Usuarios();
                Entidades.Estudiante Estudiante = solicitudes.TraerEstudiante(SolicitudSeleccionada[1]);
                Entidades.Correos correo = new Entidades.Correos();
                

                if (Session["Usuario"] != null) {
                    Funcionario = (Entidades.Usuarios)Session["Usuario"];

                    if (Funcionario.IdRol != 4) {
                        Response.Redirect("Logout.aspx");
                    }
                }
                else {
                    Response.Redirect("Logout.aspx");
                }
                Entidades.Funcionarios DatosFuncionario = solicitudes.TraerFuncionario(Funcionario.Cedula);

                //Cambiar estado de solicitud
                
                solicitudes.CambiarEstadoSolicitudRegistro(Convert.ToInt32(SolicitudSeleccionada[0]),2,Funcionario.Cedula,"");

                //Notificar al estudiante
                correo.NotificacionRespuestaRegistro(Estudiante.Correo,$"{Estudiante.NombreEstudiante} {Estudiante.Apellido1} {Estudiante.Apellido2}","Aprobada","",$"{DatosFuncionario.NombreFuncionario} {DatosFuncionario.ApellidosFuncionario}");

                //Enviar credenciales al estudiante
                Negocio.Login inicio=new Negocio.Login();
                Entidades.Usuarios CredencialesEstudiante = inicio.TraerUsuario(Estudiante.CedulaEstudiante);
                solicitudes.EnviarCredencialesEstudiante(CredencialesEstudiante.Cedula,CredencialesEstudiante.Contrasena);

                Session["Mensaje"] = "success;¡Solicitud de registro aprobada!,se le notificará al estudiante por correo electrónico sus credenciales de acceso al sistema y el estado de su solicitud de registro";
                Response.Redirect("Responder_Registro.aspx");

            }
            else
            {
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('¡Debe seleccionar una solicitud de registro para aprobarla/rechazarla!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }


        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!lstSolicitudes.SelectedValue.Equals("Seleccione una solicitud"))
            {
                //Cargar informacion
                string[] SolicitudSeleccionada = lstSolicitudes.SelectedValue.Split('-');
                Entidades.Usuarios Funcionario = new Entidades.Usuarios();
                Entidades.Estudiante Estudiante = solicitudes.TraerEstudiante(SolicitudSeleccionada[1]);
                Entidades.Correos correo = new Entidades.Correos();


                if (Session["Usuario"] != null)
                {
                    Funcionario = (Entidades.Usuarios)Session["Usuario"];

                    if (Funcionario.IdRol != 4)
                    {
                        Response.Redirect("Logout.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }
                Entidades.Funcionarios DatosFuncionario = solicitudes.TraerFuncionario(Funcionario.Cedula);


                if (!txtMotivo.Value.Equals(""))
                {
                    //Cambiar estado de solicitud

                    solicitudes.CambiarEstadoSolicitudRegistro(Convert.ToInt32(SolicitudSeleccionada[0]), 3, Funcionario.Cedula, txtMotivo.Value);

                    //Notificar al estudiante
                    correo.NotificacionRespuestaRegistro(Estudiante.Correo, $"{Estudiante.NombreEstudiante} {Estudiante.Apellido1} {Estudiante.Apellido2}", "Rechazada", txtMotivo.Value, $"{DatosFuncionario.NombreFuncionario} {DatosFuncionario.ApellidosFuncionario}");

                    Session["Mensaje"] = "success;¡Solicitud de registro rechazada!, se le notificará al estudiante por correo electrónico el estado de su solicitud de registro enviada";

                    Response.Redirect("Responder_Registro.aspx");
                }
                else {
                    string scriptalerta =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('¡Debe ingresar el motivo del rechazo de la solicitud!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }
            }
            else {
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('¡Debe seleccionar una solicitud de registro para aprobarla/rechazarla!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
        }
    }
}