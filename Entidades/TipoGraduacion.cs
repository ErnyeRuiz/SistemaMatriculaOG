using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoGraduacion
    {
        //[Key]
        public int IdTipoGraduacion { get; set;}
        public string NombreTipoG { get; set; }
             
      //  public ICollection<SolicitudesGraduacion> solicitudesGraduacions { set; get; }

    }
}
