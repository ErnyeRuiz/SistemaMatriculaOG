using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Datos;
using Entidades;

namespace Negocio
{
    public class SolicitudgraduacionAprobadas
    {
        private string connectionString;

        public SolicitudgraduacionAprobadas()
        {
            Datos.ConexionBD conexionBD = new Datos.ConexionBD();
            this.connectionString = conexionBD.ConnectionString;
        }

        public List<Entidades.SolicitudesGraduacion> ObtenerSolicitudesAprobadas(int idCarrera)
        {
            List<Entidades.SolicitudesGraduacion> solicitudesAprobadas = new List<Entidades.SolicitudesGraduacion>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("ObtenerSolicitudesAprobadas", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idCarrera", idCarrera);
                    command.Parameters.AddWithValue("@Estado", "Aprobada");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.SolicitudesGraduacion solicitud = new Entidades.SolicitudesGraduacion();
                        {
                            solicitud.IdSolicitudGraduacion = Convert.ToInt32(reader["idSolicitudGraduacion"].ToString());
                            solicitud.CedulaEstudiante = reader["CedulaEstudiante"].ToString();
                            solicitud.FechaHoraEnvio = DateTime.Parse(reader["FechaHoraEnvio"].ToString());
                            solicitud.FechaHoraRespuesta = DateTime.Parse(reader["FechaHoraRespuesta"].ToString());
                            solicitud.IdTipoG = Convert.ToInt32(reader["idTipoG"].ToString());
                            solicitud.IdEstado = Convert.ToInt32(reader["idEstado"].ToString());
                        };

                        solicitudesAprobadas.Add(solicitud);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las solicitudes aprobadas: " + ex.Message);
            }



            return solicitudesAprobadas;
        }

        public string traersolicitud(int idSolicitud)

        {
            string solicitud = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("ObtenerDatosGraduacion", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        {


                            solicitud = $"{reader["NombreEstudiante"].ToString()};{reader["Apellido1"].ToString()};{reader["Apellido2"].ToString()};{reader["Correo"].ToString()};{reader["NumeroTelefono"].ToString()};{reader["FechaHoraEnvio"].ToString()};{reader["FechaHoraRespuesta"].ToString()};{reader["Carrera"].ToString()};{reader["Carrera"].ToString()};{reader["NombreFuncionario"].ToString()};{reader["ApellidosFuncionario"].ToString()}";

                        };


                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las solicitudes aprobadas: " + ex.Message);
            }


            return solicitud;
        }



        public List<Entidades.Carreras> TraerCarrera()
        {
            List<Entidades.Carreras> lst= new List<Carreras> ();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("ConsultaCarreras", connection);
                    command.CommandType = CommandType.StoredProcedure;
                   
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Carreras carrera = new Entidades.Carreras();

                       carrera._IdCarrera = Convert.ToInt32 (reader["idCarrera"].ToString());
                       carrera._NombreCarrera = reader ["NombreCarrera"] .ToString();   
                       lst.Add(carrera);   


                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las solicitudes aprobadas: " + ex.Message);
            }

            return lst; 
        }



        public Entidades.DirectoresCarrera TraerDirector(string cedula )
            
        {
            
            Entidades.DirectoresCarrera director= new Entidades.DirectoresCarrera() ;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand("ConsultarDirector", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CedulaDirector", cedula);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    
                        director._CarreraDirectorC = reader["CarreraDirectorC"].ToString ();
                        director._CedulaDirectorCarrera = reader["CedulaDirectorC"].ToString();
                        director._NombreDirectorCarrera= reader["NombreDirectorC"].ToString();
                        director._ApellidosDirectorCarrera = reader["ApellidosDirectorC"].ToString();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las solicitudes aprobadas: " + ex.Message);
            }

            return director;
        }

        public List<Entidades.TipoGraduacion> CargarTiposOG()
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
    }
}
