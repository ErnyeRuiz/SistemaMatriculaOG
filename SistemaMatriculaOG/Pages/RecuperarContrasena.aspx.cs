using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtCedula.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", "mostrarError('Se requiere ingresar la cédula.')", true);
                return;
            }

            if (TxtCedula.Text.Length < 9)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", "mostrarError('La cédula no cumple con la longitud mínima requerida.')", true);
                return;
            }

            Entidades.Estudiante estudiante = Negocio.Estudiante.BuscarEstudiante(TxtCedula.Text);

            string Cedula = TxtCedula.Text;
            string NombreEstudiante = estudiante.NombreEstudiante + " " + estudiante.Apellido1 + " " + estudiante.Apellido2;

            if (estudiante!=null)
            {
                //Validamos que haya hecho su primer inicio de sesion
                CambioContraseña con = new CambioContraseña();
                string EstadoPrimerIngreso = con.ValidarPrimerIngreso(estudiante.CedulaEstudiante);

                if(EstadoPrimerIngreso=="1") //1 si ya iniciado sesion al menos una vez
                {
                    GeneradorContrasenias generador = new GeneradorContrasenias();
                    string contraseniatemporal = generador.GenerarContrasenia();

                    Correos correo = new Correos();

                
                    con.RecuperarContra(estudiante.CedulaEstudiante);

                    con.CambioContrasenia(estudiante.CedulaEstudiante, contraseniatemporal, true);

                    string CorreooEnviado = correo.EnviodeCredenciales(estudiante.Correo, estudiante.CedulaEstudiante, contraseniatemporal, NombreEstudiante);

                    string mensaje = "En cuanto sea respondida su solicitud de recuperación de contraseña le enviaremos sus credenciales por correo electrónico, por favor estar al pendiente de su bandeja de entrada, gracias.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarMensaje", $"mostrarMensaje('{mensaje}')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", $"mostrarError('{EstadoPrimerIngreso}')", true);

                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", "mostrarError('Cédula no pertenece a ningún usuario')", true);
                return;
            }
        }

    }
}
