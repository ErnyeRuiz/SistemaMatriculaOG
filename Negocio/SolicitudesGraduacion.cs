using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
