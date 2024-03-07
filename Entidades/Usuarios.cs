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

        public string Cedula1 { get => Cedula; set => Cedula = value; }
        public string Contrasena1 { get => Contrasena; set => Contrasena = value; }
        public int IdRol1 { get => IdRol; set => IdRol = value; }
    }
}
