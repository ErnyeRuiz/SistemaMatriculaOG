using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CambioContraseña
    {
        public void CambioContrasenia(string cedula,string contrasenia,bool EstadoIngreso) { 
            ConexionBD con=new ConexionBD();
            con.CambioContrasenia(cedula,contrasenia,EstadoIngreso);
        }
        public void RecuperarContra(string cedula)
        {
            ConexionBD con = new ConexionBD();
            con.CambioIngreso(cedula);
        }
        public string ValidarPrimerIngreso(string cedula) //Valida si un usuario ya hecho su primer ingreso
        {
            try
            {
                ConexionBD con = new ConexionBD();

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@CedulaEstudiante";
                sqlParameter.Value = cedula;
                sqlParameter.SqlDbType = System.Data.SqlDbType.VarChar;

                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    sqlParameter
                };

                int result = con.ExecuteSPWithInt("VerificarPrimerIngreso", sqlParameters);

                switch (result)
                {
                    case 0:
                        return "No ha realizado su primer ingreso al sistema.";
                    case 1:
                        return "1"; //El usuario ya hizo su primer inicio de sesion
                    case -1:
                        return "Usuario no encontrado";
                    default:
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
