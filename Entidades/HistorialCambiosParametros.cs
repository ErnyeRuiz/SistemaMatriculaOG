using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistorialCambiosParametros
    {
        int _IdCambio;
        int _IdParametro;
        DateTime _FechaHoraUltimoCambio;
        string _CedulaFuncionario;
       // [Key]       
           
        public int IdCambio { get => _IdCambio; set => _IdCambio = value; }
        public int IdParametro { get => _IdParametro; set => _IdParametro = value; }
        public DateTime FechaHoraUltimoCambio { get => _FechaHoraUltimoCambio; set => _FechaHoraUltimoCambio = value; }
        public string CedulaFuncionario { get => _CedulaFuncionario; set => _CedulaFuncionario = value; } 
        //public virtual ParametrosSistema ParametrosSistema { get; set; }
    }
}
