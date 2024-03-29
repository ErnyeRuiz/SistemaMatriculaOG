using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carreras
    {
        int IdCarrera; //primary key
        string NombreCarrera; //not null
        //Key]
        public int _IdCarrera { get => IdCarrera; set => IdCarrera = value; }
        public string _NombreCarrera { get => NombreCarrera; set => NombreCarrera = value; }

      //  public virtual ICollection<DirectoresCarrera> DirectoresCarreras { get; set; }
        //public virtual ICollection<Estudiante> Estudiantes { get; set; }

    }
}
