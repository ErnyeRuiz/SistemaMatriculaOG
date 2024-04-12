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
        string _Correo;
        string _NumeroTelefono;
        string _Tipo;
        DateTime _FechaEnvio;
        string _Estado;

        public int IdSolicitud { get => _IdSolicitud; set => _IdSolicitud = value; }
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        public string Carrera { get => _Carrera; set => _Carrera = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public DateTime Fecha { get => _FechaEnvio; set => _FechaEnvio = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string NumeroTelefono { get => _NumeroTelefono; set => _NumeroTelefono = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
