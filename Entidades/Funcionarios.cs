using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionarios
    {
        string _CedulaFuncionario;
        string _NombreFuncionario;
        string _ApellidosFuncionario;
     //   [Key]
        public string CedulaFuncionario { get => _CedulaFuncionario; set => _CedulaFuncionario = value; }
        public string NombreFuncionario { get => _NombreFuncionario; set => _NombreFuncionario = value; }
        public string ApellidosFuncionario { get => _ApellidosFuncionario; set => _ApellidosFuncionario = value; }

       // public ICollection<SolicitudesGraduacion> solicitudesGraduacion { get; set; }
    }
}
