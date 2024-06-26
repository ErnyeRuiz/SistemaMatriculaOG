﻿using Entidades;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class SolicitudesGraduacion
    {
        public static List<Entidades.TipoGraduacion> CargarTiposOG()
        {
            Datos.ConexionBD conexionBD = new Datos.ConexionBD();

            var tabla = conexionBD.ExecuteSPWithDT("TraerTiposOG", null);

            List<Entidades.TipoGraduacion> listaOG = new List<Entidades.TipoGraduacion>();
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Entidades.TipoGraduacion og = new Entidades.TipoGraduacion
                    {
                        IdTipoGraduacion = Convert.ToInt16(fila[0]),
                        NombreTipoG = fila[1].ToString()
                    };
                    listaOG.Add(og);
                }

                return listaOG;
            }
            return null;
        }
        public static void AgregarSolicitudOG(string cedula, string NombreTipoOG)
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@cedula", SqlDbType.VarChar) { Value = cedula },
                    new SqlParameter("@NombreTipoOG", SqlDbType.VarChar){Value = NombreTipoOG}
                };

                conexionBD.ExecuteSP("AgregarSolicitudOG", sqlParameters);
            }
            catch (Exception exc)
            {

            }
        }//Metofdo para validar si el estudiante ya envio una solicitud de og
        public static bool ValidarEstudianteEnvioOG(string cedula)
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@cedula", SqlDbType.VarChar) { Value = cedula },
                };
                int result = conexionBD.ExecuteSPWithInt("ValidarEstudianteEnvioOG", sqlParameters);

                //validamos si result = 1 se retorna false
                return (result == 1) ? false : true;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public static List<VistaSolicitudesPendientes> VerSolicitudesOGPendientes()
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                List<VistaSolicitudesPendientes> lista = new List<VistaSolicitudesPendientes>();

                var tabla = conexionBD.ExecuteSPWithDT("CargarSolicitudesOGPendientes", null);

                if (tabla != null)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        Entidades.VistaSolicitudesPendientes v = new VistaSolicitudesPendientes
                        {
                            IdSolicitud = Convert.ToInt16(fila[0]),
                            IdCarrera = Convert.ToInt16(fila[1]),
                            Carrera = fila[2].ToString(),
                            Nombre = fila[3].ToString(),
                            Apellidos = fila[4].ToString(),
                            Cedula = fila[5].ToString(),
                            Correo = fila[6].ToString(),
                            NumeroTelefono = fila[7].ToString(),
                            Tipo = fila[8].ToString(),
                            Fecha = Convert.ToDateTime(fila[9].ToString()),
                            Estado = fila[10].ToString()
                        };
                        lista.Add(v);
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static List<Entidades.Carreras> VerCarreras()
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                List<Carreras> lista = new List<Carreras>();

                var tabla = conexionBD.ExecuteSPWithDT("TraerCarreras", null);

                if (tabla != null)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        Carreras c = new Carreras
                        {
                            _IdCarrera = Convert.ToInt16(fila[0].ToString()),
                            _NombreCarrera = fila[1].ToString(),
                        };
                        lista.Add(c);
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }

        }
        //SI ES 1 SE APRUEBA, SI ES 2 SE RECHAZA
        public static void CambiarEstadoSolicitudOG(int idSolicitud, string motivo, string cedulaFuncionario)
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                string nombreFuncionario = TraerFuncionario(cedulaFuncionario);

                SqlParameter motivoP = new SqlParameter("@Motivo", SqlDbType.VarChar);
                if (motivo == null)
                {
                    motivoP.Value = DBNull.Value;
                }
                else
                {
                    motivoP.Value = motivo;
                }
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdSolicitud", SqlDbType.Int) { Value = idSolicitud },
                    motivoP,
                    new SqlParameter("@CedulaFuncionario",SqlDbType.VarChar){Value = cedulaFuncionario}
                };                

                if (nombreFuncionario != null)
                {                    
                    EnviarEmailCambioEstadoSolicitudOG(idSolicitud, nombreFuncionario, motivo);
                    conexionBD.ExecuteSP("CambiarEstadoSolicitudOG", sqlParameters);

                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public static string ValidarEnvioOGAbierta()
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                var result = conexionBD.ExecuteSPWithDT("ConsultarParametrosSistema",null);

                if (result == null)
                {
                    throw new Exception("No se pudo consultar la fecha y hora de apertura de envio");
                }
                DateTime inicio = DateTime.MinValue , cierre = DateTime.MinValue;

                foreach(DataRow fila in result.Rows)
                {
                    inicio = Convert.ToDateTime(fila[1].ToString());
                    cierre = Convert.ToDateTime(fila[2].ToString());
                }

                DateTime Ahora = DateTime.Now;

                if(Ahora>=inicio && Ahora <= cierre)
                {
                    return "Valido" ;
                }
                string respuesta = $"La matrícula de opción de graduación no está habilitada en este momento, sino desde: " +
                    $"{inicio:dd/MM/yy} a las {inicio:HH:mm} hasta: {cierre:dd/MM/yy} a las {cierre:HH:mm}";
                return respuesta;

            }
            catch (Exception)
            {
                throw new Exception("Algo salio mal en la carga de parametros");
            }

        }

        private static void EnviarEmailCambioEstadoSolicitudOG(int IdSolicitud, string nombreFuncionario, string motivo)
        {
            try {
                List<VistaSolicitudesPendientes> solicitudesTotales = VerSolicitudesOGPendientes();

                if (solicitudesTotales != null)
                {
                    var solicitud = solicitudesTotales.FirstOrDefault(s=>s.IdSolicitud==IdSolicitud);

                    if (solicitud != null)
                    {
                        //Encontramos la solicitud 
                        //envio de correo al estudiante
                        Correos correo = new Correos();

                        var result = correo.EnviarCorreoCambioEstadoSolicitudOG(solicitud,nombreFuncionario,motivo);
                    }
                }
            }
            catch (Exception)
            {

            }          
        }

        private static string TraerFuncionario(string cedula)
        {
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                SqlParameter cedulaP = new SqlParameter("@CedulaFuncionario", SqlDbType.VarChar);
                cedulaP.Value = cedula;
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(cedulaP);
                var tabla = conexionBD.ExecuteSPWithDT("TraerFuncionario", sqlParameters);

                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        return fila[1].ToString() + " " + fila[2].ToString();
                     }
                }
                return null;
                }
            catch (Exception)
            {
                throw new Exception("Error al traer el funcionario");
            }
        }
    }
}
