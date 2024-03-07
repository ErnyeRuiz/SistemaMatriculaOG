using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Roles
    {
        int IdRol; //primary key
        string NombreRol; //not null

        public int IdRol1 { get => IdRol; set => IdRol = value; }
        public string NombreRol1 { get => NombreRol; set => NombreRol = value; }
    }
}
