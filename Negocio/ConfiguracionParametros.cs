using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConfiguracionParametros
    {

        public Entidades.ParametrosSistema TraerParametrosSistema() { 
            ConexionBD con=new ConexionBD();
            return con.TraerParametrosSistema();
        }

        public void ModificarParametrosSistema(DateTime FechaHoraInicio,DateTime FechaHoraCierre,string CedulaFuncionario) { 
            ConexionBD con=new ConexionBD();
            con.ModificarParametrosSistema(FechaHoraInicio,FechaHoraCierre,CedulaFuncionario);
        }

        public string NombreCompletoFuncionarioUltimoCambio() { 
            ConexionBD con=new ConexionBD();
            return con.NombreFuncionarioUltimoCambio();
        }

    }
}
