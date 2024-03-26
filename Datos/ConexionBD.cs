using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionBD
    {        
        public SqlConnection conexion;

        public ConexionBD()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString);
        }
        //Procedimiento almacenado
        public void ExecuteSP(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.conexion
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);


                conexion.Open();

                cmd.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException sql)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Procedimiento almacenado retorna DataTable
        public DataTable ExecuteSPWithDT(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = SPName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.conexion
                };

                if (ListaParametros != null && ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(ListaParametros.ToArray());

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                
                adapter.Fill(dtDatos);

                return dtDatos;
            }
            catch (SqlException sql)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Retorna un solo valor entero
        public int ExecuteSPWithInt(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.conexion
                };
                if (ListaParametros != null)
                {
                    foreach (SqlParameter sqlParam in ListaParametros)
                        cmd.Parameters.Add(sqlParam);
                }


                conexion.Open();

                object result = cmd.ExecuteScalar();

                conexion.Close();

                return Convert.ToInt32(result);
            }
            catch (SqlException sql)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Sebas

        #region Login
        //Validar  usuario
        public string ValidarUsuario(string cedula, string password)
        {

            string Mensaje = "";
            conexion.Open();
            SqlCommand command = new SqlCommand("ValidarLogin", conexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cedula", cedula);
            command.Parameters.AddWithValue("@Contrasena", password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Mensaje = reader["Respuesta"].ToString();
                }
            }
            conexion.Close();

            return Mensaje;
        }


        //Traer Usuario
        public Usuarios TraerUsuario(string cedula)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("TraerUsuario", conexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cedula", cedula);
            Usuarios user = new Usuarios();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    user.Cedula1= reader["Cedula"].ToString();
                    user.Contrasena1= reader["Contrasena"].ToString();
                    user.IdRol1 = Convert.ToInt32(reader["IdRol"].ToString());
                    user.P_Ingreso1 = Convert.ToBoolean(reader["P_Ingreso"].ToString());
                }
            }
            conexion.Close();

            return user;
        }

        #endregion

        #region RegistrarUsuario
        //Registrar Usuario
        public void RegistroUsuario(string cedula, string password,int rol)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("RegistrarUsuario", conexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cedula", cedula);
            command.Parameters.AddWithValue("@Contrasena", password);
            command.Parameters.AddWithValue("@IDRol", rol);

            command.ExecuteNonQuery();

            conexion.Close();

        }

        //Registrar Estudiante
        public void RegistroEstudiante(string cedula,string Nombre,string Apellido1,string Apellido2
            ,string Nacionalidad,string Correo,string telefono,DateTime FechaNac,int IDCarrera)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("RegistrarEstudiante", conexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Cedula", cedula);
            command.Parameters.AddWithValue("@Nombre",Nombre);
            command.Parameters.AddWithValue("@Apellido1",Apellido1);
            command.Parameters.AddWithValue("@Apellido2",Apellido2);
            command.Parameters.AddWithValue("@Nacionalidad",Nacionalidad);
            command.Parameters.AddWithValue("@Correo",Correo);
            command.Parameters.AddWithValue("@Telefono",telefono);
            command.Parameters.AddWithValue("@FechaNac",FechaNac);
            command.Parameters.AddWithValue("@IDCarrera",IDCarrera);



            command.ExecuteNonQuery();

            conexion.Close();

        }

        //Registrar solicitud
        public void RegistroSolicitudDeRegistro(string cedula, int IDEstadoSolicitud)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("IngresarSoliRegistro", conexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CedulaEstudiante", cedula);
            command.Parameters.AddWithValue("@idEstadoSolicitud", IDEstadoSolicitud);

            command.ExecuteNonQuery();

            conexion.Close();

        }

        //Traer lista de carreras
        public List<Carreras> TraerCarreras()
        {

            List<Carreras> lst= new List<Carreras>();
            conexion.Open();
            SqlCommand command = new SqlCommand("TraerCarreras", conexion);

            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Carreras carrera = new Carreras();
                    carrera.IdCarrera1=Convert.ToInt32(reader["IdCarrera"].ToString());
                    carrera.NombreCarrera1 = reader["NombreCarrera"].ToString();
                    lst.Add(carrera);
                }
            }
            conexion.Close();

            return lst;
        }



        #endregion

        #endregion

    }

}
