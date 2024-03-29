using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadosSolicitud
    {
        int _Estado;
        string _NombreEstado;
        //[Key]
        public int Estado { get => _Estado; set => _Estado = value; }
        public string NombreEstado { get => _NombreEstado; set => _NombreEstado = value; }
        
        //public ICollection<SolicitudesGraduacion> solicitudesGraduacions { set; get; }
        //public ICollection<SolicitudesRegistro> solicitudesRegistros { set; get; }  
    }
}
