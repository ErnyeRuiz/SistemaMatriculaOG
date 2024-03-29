using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ParametrosSistema
    {
        int _IdParametro;
        DateTime _FechaHoraInicio;
        DateTime _FechaHoraCierre;
        [Key]
        public int IdParametro { get => _IdParametro; set => _IdParametro = value; }
        public DateTime FechaHoraInicio { get => _FechaHoraInicio; set => _FechaHoraInicio = value; }
        public DateTime FechaHoraCierre { get => _FechaHoraCierre; set => _FechaHoraCierre = value; }
      //  public ICollection<HistorialCambiosParametros> HistorialCambiosParametros { get; set; }
    
    }
}
