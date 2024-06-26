﻿using System;
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
        public String NotificacionRespuestaRegistro(string CorreoEstudiante,string NombreCompletoEstudiante,string EstadoSolicitud,string Motivo,string NombreCompletoFuncionario)
        {
            string respuesta = "";
            try
            {
                
                // Datos del destinatario
                string destinatarioEmail = CorreoEstudiante;

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(Email, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(Email, destinatarioEmail);
                mensaje.Subject = "Notificación de respuesta de registro al sistema";

                if (EstadoSolicitud.Equals("Aprobada")) {
                    mensaje.Body = $"Estimado {NombreCompletoEstudiante} la respuesta a su solicitud de registro fue {EstadoSolicitud} por el departamento de registro."
                        +Environment.NewLine+ Environment.NewLine +
                        $"Atentamente: {NombreCompletoFuncionario}."+Environment.NewLine+
                        "Dpto. Registro."+Environment.NewLine+
                        $"Fecha de respuesta: {DateTime.Now.ToShortDateString()}";



                } else if (EstadoSolicitud.Equals("Rechazada")) {
                    mensaje.Body = $"Estimado {NombreCompletoEstudiante} la respuesta a su solicitud de registro fue {EstadoSolicitud} debido a:"
                        + Environment.NewLine + Environment.NewLine +
                        "Motivo de rechazo de la solicitud:" +Environment.NewLine+
                        $"{Motivo}"+Environment.NewLine+ Environment.NewLine +
                        $"Atentamente: {NombreCompletoFuncionario}." + Environment.NewLine +
                        "Dpto. Registro." + Environment.NewLine +
                        $"Fecha de respuesta: {DateTime.Now.ToShortDateString()}";
                }
                

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

        public String EnviodeCredenciales(string CorreoEstudiante,string cedula,string ContraseniaTemporal,string NombreCompletoEstudiante)
        {
            string respuesta = "";
            try
            {

                // Datos del destinatario
                string destinatarioEmail = CorreoEstudiante;

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(Email, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(Email, destinatarioEmail);
                mensaje.Subject = "Credenciales de acceso a la plataforma";
                mensaje.Body = $"Estimado {NombreCompletoEstudiante} a continuación le brindaremos sus credenciales de acceso al sistema:"
                    +Environment.NewLine+ Environment.NewLine +
                    $"Cedula: {cedula}"+Environment.NewLine+
                    $"Clave de acceso temporal: {ContraseniaTemporal}";


                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                //Salida de la operacion
                respuesta = "Credenciales enviados al estudiante";
            }
            catch (Exception ex)
            {
                //Salida de la operacion
                respuesta = "Error al enviar el correo: " + ex.Message;
            }
            return respuesta;
        }

        public bool EnviarCorreoCambioEstadoSolicitudOG(VistaSolicitudesPendientes solicitud, string nombreFuncionario, string motivo)
        {
            try
            {
                //vairables locales

                DateTime ahora = DateTime.Now;
                string subject = "Aprobación en su solicitud de Opcion de graduación";

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(Email, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(Email, solicitud.Correo);

                //Validamos si es aceptada o rechazada

                if (motivo != null) //rechgzada
                {
                    subject = "Rechazo en su solicitud de Opcion de graduación";

                    mensaje.Subject = subject;
                    mensaje.Body = $"Estimado {solicitud.Nombre + ' ' + solicitud.Apellidos} la respuesta a su solicitud de matrícula de opción de graduación " +
                        $"fue Rechazada."
                        + Environment.NewLine + Environment.NewLine +
                        "Motivo de rechazo de solicitud:"
                        + Environment.NewLine + Environment.NewLine +
                        $"{motivo}"
                        + Environment.NewLine + Environment.NewLine +
                        $"Atentamente: {nombreFuncionario}"
                        + Environment.NewLine + Environment.NewLine +
                        "Dpto. Registro."
                        + Environment.NewLine + Environment.NewLine +
                        $"Fecha de respuesta: {ahora.ToString()}";                      
                }
                else //aprobada
                {
                    mensaje.Subject = subject;
                    mensaje.Body = $"Estimado {solicitud.Nombre + ' ' + solicitud.Apellidos} la respuesta a su solicitud matrícula de opción de graduación " +
                    $"fue Aprobada por el departamento de registro."
                    + Environment.NewLine + Environment.NewLine +
                    $" Atentamente: {nombreFuncionario}." +
                    Environment.NewLine + Environment.NewLine +
                    $" Dpto. Registro." +
                    Environment.NewLine + Environment.NewLine +
                    $"Fecha de respuesta: {ahora.ToString()}";                   
                }                              
                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
