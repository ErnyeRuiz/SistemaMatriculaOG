using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        string _Cedula; //primary key
        string _Contrasena; //not null
        int _IdRol; //not null foreign key
        bool _P_Ingreso; //not null bit
        //[Key]
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public int IdRol { get => _IdRol; set => _IdRol = value; }
        public bool P_Ingreso { get => _P_Ingreso; set => _P_Ingreso = value; }
        //public virtual Roles Roles { get; set; }
    }
}
