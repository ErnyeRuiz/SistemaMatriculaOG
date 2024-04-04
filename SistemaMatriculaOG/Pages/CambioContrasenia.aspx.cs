using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class CambioContrasenia : System.Web.UI.Page
    {
        Entidades.Usuarios usuario =new Entidades.Usuarios();
        Negocio.SolicitudesRegistro operador=new Negocio.SolicitudesRegistro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                usuario = (Entidades.Usuarios)Session["Usuario"];
                if (usuario.IdRol == 3 || usuario.IdRol == 4)
                {
                    Response.Redirect("Logout.aspx");
                }

                Entidades.Estudiante estudiante=operador.TraerEstudiante(usuario.Cedula);


                Dato1.Text=$"{estudiante.NombreEstudiante} {estudiante.Apellido1} {estudiante.Apellido2}";
                Dato2.Text = $"{estudiante.CedulaEstudiante}";
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (!txtPassN.Text.Equals("") && !txtPassN2.Text.Equals(""))
            {
                if (!txtPassN.Text.Equals(usuario.Contrasena))
                {
                    validacion1.Visible = false;
                    lblValidacion1.Text = "";
                    if (txtPassN2.Text.Equals(txtPassN.Text))
                    {
                        validacion2.Visible = false;
                        lblValidacion2.Text = "";

                        //Cambiar el estado de la variable de inicio por primera vez en BD y la contraseña del usuario
                        Negocio.CambioContraseña cambio = new Negocio.CambioContraseña();
                        cambio.CambioContrasenia(usuario.Cedula, txtPassN.Text, false);

                        Session["Mensaje"] = "¡Contraseña cambiada correctamente!";
                        if (usuario.IdRol == 1)
                        {
                            Response.Redirect("PP_Estudiantes.aspx");
                        }
                        else if (usuario.IdRol == 2)
                        {
                            Response.Redirect("PP_Egresados.aspx");
                        }
                    }
                    else
                    {
                        validacion2.Visible = true;
                        lblValidacion2.Text = "¡La contraseña nueva y el espacio de confirmación no coinciden!";
                    }
                }
                else
                {
                    validacion1.Visible = true;
                    lblValidacion1.Text = "¡La contraseña nueva y la temporal no pueden ser iguales!";
                }
            }
            else {
                validacion1.Visible = false;
                lblValidacion1.Text = "";
                validacion2.Visible = false;
                lblValidacion2.Text = "";

                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('¡Faltan campos obligatorios por ingresar!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
        }
    }
}