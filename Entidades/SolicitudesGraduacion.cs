using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolicitudesGraduacion
    {
        int _IdSolicitudGraduacion;
        string _CedulaEstudiante;
        DateTime _FechaHoraEnvio;
        DateTime _FechaHoraRespuesta;
        int _IdEstado;
        int _IdTipoG;
        string _Motivo;
        string _CedulaFuncionario;
        //[Key]
        public int IdSolicitudGraduacion { get => _IdSolicitudGraduacion; set => _IdSolicitudGraduacion = value; }
        public string CedulaEstudiante { get => _CedulaEstudiante; set => _CedulaEstudiante = value; }
        public DateTime FechaHoraEnvio { get => _FechaHoraEnvio; set => _FechaHoraEnvio = value; }
        public DateTime FechaHoraRespuesta { get => _FechaHoraRespuesta; set => _FechaHoraRespuesta = value; }
        public int IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public int IdTipoG { get => _IdTipoG; set => _IdTipoG = value; }
        public string Motivo { get => _Motivo; set => _Motivo = value; }
        public string CedulaFuncionario { get => _CedulaFuncionario; set => _CedulaFuncionario = value; }
        //public virtual Estudiante Estudiante { get; set; }
        //public virtual EstadosSolicitud EstadosSolicitud { set; get; }
        //public virtual TipoGraduacion TipoGraduacion { get; set;}
        //public virtual Funcionarios Funcionarios { get; set;}
    }
}
