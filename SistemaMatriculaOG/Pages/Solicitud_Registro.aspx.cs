using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Solicitud_Registro : System.Web.UI.Page
    {
        Entidades.SolicitudesRegistro SolicitudesR = new Entidades.SolicitudesRegistro();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lstCarreras.Items.Add("Seleccione una carrera");
                //foreach (Carreras c in SolicitudesR.TraerCarreras())
                //{
                //    lstCarreras.Items.Add($"{c.IdCarrera1}-{c.NombreCarrera1}");
                //}

            }

            if (Session["Mensaje"]!=null) {
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.success('{Convert.ToString(Session["Mensaje"])}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrSuccess", scriptalerta, true);
                Session["Mensaje"]=null;
            }

           
        }

        //protected void btnRegistrarse_Click(object sender, EventArgs e)
        //{
        //    //validaciones
        //    if (!txtCedula.Text.Equals("") && !txtNombre.Text.Equals("") && !txtapellido1.Text.Equals("") && !txtapellido2.Text.Equals("")
        //        && !txtNacionalidad.Text.Equals("") && !txtCorreo.Text.Equals("") && !txtFechaNac.Text.Equals("")
        //        && !lstCarreras.Text.Equals("Seleccione una carrera"))
        //    {
        //        GeneradorContrasenias generador = new GeneradorContrasenias();
        //        string contraseniatemporal = generador.GenerarContrasenia();
        //        bool PermitirRegistro = true;
        //        //Datos
        //        string cedula = txtCedula.Text;//Alfanumerico
        //        string correo = txtCorreo.Text;//Alfanumerico

        //        string nombre = txtNombre.Text;//Letras
        //        string apellido1 = txtapellido1.Text;//Letras
        //        string apellido2 = txtapellido2.Text;//Letras
        //        string nacionalidad = txtNacionalidad.Text;//Letras

        //        string telefono = txtTelefono.Text;//Numeros

        //        DateTime FechaNac = DateTime.Parse(txtFechaNac.Text);
        //        string carreraseleccionada = lstCarreras.Text;
        //        string[] DatosCarrera=carreraseleccionada.Split('-');

        //        if (!(cedula.Length >= 9 && cedula.Length <= 15))
        //        {
        //            //Mensaje
        //            PermitirRegistro = false;
        //            string scriptalerta =
        //            "toastr.options.closeButton = true;" +
        //            "toastr.options.positionClass = 'toast-bottom-right';" +
        //            $"toastr.error('¡Debe ingresar información valida!(Identificación)');";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
        //        }
        //        if (!correo.Contains("@"))
        //        {
        //            //Mensaje
        //            PermitirRegistro = false;
        //            string scriptalerta =
        //            "toastr.options.closeButton = true;" +
        //            "toastr.options.positionClass = 'toast-bottom-right';" +
        //            $"toastr.error('¡Debe ingresar información valida!(Correo)');";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
        //        }
        //        DateTime FechaActualmentePermitida = DateTime.Now.AddYears(-18);
        //        if (!(FechaNac.Year <= FechaActualmentePermitida.Year))
        //        {
        //            //Mensaje
        //            PermitirRegistro = false;
        //            string scriptalerta =
        //            "toastr.options.closeButton = true;" +
        //            "toastr.options.positionClass = 'toast-bottom-right';" +
        //            $"toastr.error('¡Debe ingresar información valida!(Fecha)');";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
        //        }

        //        if (PermitirRegistro == true)
        //        {
        //            //Procedimiento

        //            //Registro del usuario
        //            SolicitudesR.RegistrarUsuario(cedula, contraseniatemporal);

        //            //Registro del estudiante
        //            SolicitudesR.RegistrarEstudiante(cedula, nombre, apellido1, apellido2, nacionalidad, correo, telefono, FechaNac, Convert.ToInt32(DatosCarrera[0]));

        //            //Registro de la solicitud de registro
        //            SolicitudesR.RegistrarSolicitud(cedula);

        //            //Mensaje procedimiento
        //            Session["Mensaje"] = "¡Envío de solicitud de registro exitoso!"+" Revisaremos tu solicitud y te daremos respuesta por medio del correo que ingresaste, "+"¡Gracias!";
                    
        //            Response.Redirect("Solicitud_Registro.aspx");
        //        }

        //    } else
        //    {
        //        string scriptalerta =
        //        "toastr.options.closeButton = true;" +
        //        "toastr.options.positionClass = 'toast-bottom-right';" +
        //        $"toastr.error('¡Debe ingresar los campos obligatorios en el formulario!');";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
        //    }


        //}
    }
}