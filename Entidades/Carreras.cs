using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carreras
    {
        int IdCarrera; //primary key
        string NombreCarrera; //not null

        public int IdCarrera1 { get => IdCarrera; set => IdCarrera = value; }
        public string NombreCarrera1 { get => NombreCarrera; set => NombreCarrera = value; }
    }
}
