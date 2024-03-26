using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        string Cedula; //primary key
        string Contrasena; //not null
        int IdRol; //not null foreign key
        bool P_Ingreso; //not null bit

        public string Cedula1 { get => Cedula; set => Cedula = value; }
        public string Contrasena1 { get => Contrasena; set => Contrasena = value; }
        public int IdRol1 { get => IdRol; set => IdRol = value; }
        public bool P_Ingreso1 { get => P_Ingreso; set => P_Ingreso = value; }
    }
}
