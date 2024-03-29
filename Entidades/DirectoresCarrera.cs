using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectoresCarrera
    {
        string CedulaDirectorCarrera;
        string NombreDirectorCarrera;
        string ApellidosDirectorCarrera;
        string CarreraDirectorC;
        //[Key]
        public string _CedulaDirectorCarrera { get => CedulaDirectorCarrera; set => CedulaDirectorCarrera = value; }
        public string _NombreDirectorCarrera { get => NombreDirectorCarrera; set => NombreDirectorCarrera = value; }
        public string _ApellidosDirectorCarrera { get => ApellidosDirectorCarrera; set => ApellidosDirectorCarrera = value; }
        public string _CarreraDirectorC { get => CarreraDirectorC; set => CarreraDirectorC = value; }

      //  public virtual Carreras Carreras { get; set; }

    }
}
