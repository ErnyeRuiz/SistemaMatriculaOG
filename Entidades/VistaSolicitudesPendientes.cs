using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VistaSolicitudesPendientes
    {
        int _IdSolicitud;
        int _IdCarrera;
        string _Carrera;
        string _Nombre;
        string _Apellidos;
        string _Cedula;
        string _Tipo;
        DateTime _Fecha;
        public int IdSolicitud { get => _IdSolicitud; set => _IdSolicitud = value; } 
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        public string Carrera { get => _Carrera; set => _Carrera = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
       
    }
}
