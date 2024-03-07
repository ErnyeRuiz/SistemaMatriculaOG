using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    }
        
}
