using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpresasEstudiante
    {
        int _IdEmpresaEstudiante;
        string _CedulaEstudiante;
        string _NombreEmpresa;
        string _Puesto;
        string _Descripcion;
        DateTime _FechaIngreso;
        DateTime _FechaSalida;
        bool _TrabajoActual;

    //    [Key]
        public int IdEmpresaEstudiante { get => _IdEmpresaEstudiante; set => _IdEmpresaEstudiante = value; }
        public string CedulaEstudiante { get => _CedulaEstudiante; set => _CedulaEstudiante = value; }
        public string NombreEmpresa { get => _NombreEmpresa; set => _NombreEmpresa = value; }
        public string Puesto { get => _Puesto; set => _Puesto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public DateTime FechaIngreso { get => _FechaIngreso; set => _FechaIngreso = value; }
        public DateTime FechaSalida { get => _FechaSalida; set => _FechaSalida = value; }
        public bool TrabajoActual { get => _TrabajoActual; set => _TrabajoActual = value; }
      //  public virtual Estudiante Estudiante { get; set; }
    }
}
