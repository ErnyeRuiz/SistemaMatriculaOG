using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correos
    {
        private string Email = "Solicitudes.opcion.graduacion@gmail.com";
        private string Contrasenia = "dcedklorccbnrzux";

        //Envío de credenciales de acceso
        public String EnviarRespuesta(string CorreoUsuario)
        {
            string respuesta = "";
            try
            {
                
                // Datos del destinatario
                string destinatarioEmail = CorreoUsuario;

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(Email, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(Email, destinatarioEmail);
                mensaje.Subject = "Correo de confirmación de registro";
                mensaje.Body = $"(Mensaje del correo)";

                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                //Salida de la operacion
                respuesta = "Correo enviado exitosamente.";
            }
            catch (Exception ex)
            {
                //Salida de la operacion
                respuesta="Error al enviar el correo: " + ex.Message;
            }
            return respuesta;
        }
    }
}
