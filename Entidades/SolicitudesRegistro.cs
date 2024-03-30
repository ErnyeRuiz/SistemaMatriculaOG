using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolicitudesRegistro
    {
        int _IdsolicitudRegistro;
        string _CedulaEstudiante;
        DateTime _FechaHoraEnvio;
        DateTime _FechaHoraRespuesta;
        string _IdEstado;
        string _Motivo;
        //[Key]
        public int IdsolicitudRegistro { get => _IdsolicitudRegistro; set => _IdsolicitudRegistro = value; }
        public string CedulaEstudiante { get => _CedulaEstudiante; set => _CedulaEstudiante = value; }
        public DateTime FechaHoraEnvio { get => _FechaHoraEnvio; set => _FechaHoraEnvio = value; }
        public DateTime FechaHoraRespuesta { get => _FechaHoraRespuesta; set => _FechaHoraRespuesta = value; }
        public string IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public string Motivo { get => _Motivo; set => _Motivo = value; }
    }
}
