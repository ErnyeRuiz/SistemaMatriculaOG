using System;
using Datos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class SolicitudGraduacionregistro
    {
        // Instancia de la capa de datos
        private ConexionBD _conexionBD;

        public SolicitudGraduacionregistro()
        {
            // Inicializa la conexión a la base de datos
            _conexionBD = new ConexionBD();
        }

        public List<Entidades.TipoGraduacion> ObtenerTiposGraduacion()
        {
            // Crea una lista para almacenar los tipos de graduación
            List<Entidades.TipoGraduacion> tiposGraduacion = new List<Entidades.TipoGraduacion>();

            // Llama al método de la capa de datos para ejecutar el procedimiento almacenado "TraerTiposOG"
            using (var dt = _conexionBD.ExecuteSPWithDT("[TI165Grupo04].[TraerTiposOG]", null))
            {
                // Recorre el DataTable y crea objetos de TipoGraduacion
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    // Crea un nuevo objeto TipoGraduacion con los valores de la fila
                    Entidades.TipoGraduacion tipoGraduacion = new Entidades.TipoGraduacion
                    {
                        IdTipoGraduacion = Convert.ToInt32(row["IdTipoGraduacion"]),
                        NombreTipoG = row["NombreTipoG"].ToString()
                    };

                    // Añade el objeto a la lista
                    tiposGraduacion.Add(tipoGraduacion);
                }
            }

            // Devuelve la lista de tipos de graduación
            return tiposGraduacion;
        }

        // Método para agregar la solicitud de graduación
        public string AgregarSolicitud(string cedula, string opcionGraduacion)
        {
            // Verifica si todos los campos requeridos son válidos
            if (string.IsNullOrEmpty(cedula))
            {
                return "La cédula del estudiante es requerida.";
            }

            if (string.IsNullOrEmpty(opcionGraduacion))
            {
                return "La opción de graduación es requerida.";
            }

            try
            {
                // Crea una nueva solicitud de opción de graduación
                Entidades.SolicitudGraduacionregistro solicitud = new Entidades.SolicitudGraduacionregistro
                {
                    CedulaEstudiante = cedula,
                    OpcionGraduacion = opcionGraduacion,
                    Estado = "pendiente" // Estado inicial de la solicitud
                };

                // Guarda la solicitud de graduación en la base de datos
                _conexionBD.RegistrarSolicitudGraduacion(solicitud);

                return "Solicitud de graduación creada exitosamente.";
            }
            catch (Exception ex)
            {
                // Maneja excepciones y errores, proporcionando mensajes más específicos
                if (ex is SqlException sqlEx)
                {
                    // Si hay un error de SQL específico, devuelve un mensaje más específico
                    switch (sqlEx.Number)
                    {
                        case 2627: // Violación de clave única
                            return "Error: Ya existe una solicitud para este estudiante.";
                        case 547: // Violación de clave externa
                            return "Error: Datos de entrada inválidos (clave externa violada).";
                        default:
                            return $"Error de base de datos: {sqlEx.Message}";
                    }
                }
                // Otros errores generales
                return $"Error al procesar la solicitud: {ex.Message}";
            }
        }
    
    

    }
}
