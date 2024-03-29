using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Roles
    {
        int _IdRol; //primary key
        string _NombreRol; //not null
    //    [Key]
        public int IdRol { get => _IdRol; set => _IdRol = value; }
        public string NombreRol { get => _NombreRol; set => _NombreRol = value; }
    
        //public ICollection<Usuarios> Usuarios { get; set; }
    }
}
