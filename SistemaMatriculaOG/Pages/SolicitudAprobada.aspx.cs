using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class SolicitudAprobada : System.Web.UI.Page
    {

        Negocio.SolicitudgraduacionAprobadas SolicitudesR = new Negocio.SolicitudgraduacionAprobadas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // string connectionString = "Data Source=SistemaSolicitudesOG;Initial Catalog=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;User ID=TI165Grupo04;Password=Fbh55p0$9;";
                SolicitudesR = new Negocio.SolicitudgraduacionAprobadas();
                List<Entidades.SolicitudesGraduacion> solicitudes = SolicitudesR.ObtenerSolicitudesAprobadas();

                GridViewSolicitudes.DataSource = solicitudes;
                GridViewSolicitudes.DataBind();
            }


        }

        protected void GridViewSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar") // Verifica si el comando es "Editar"
            {
                contenedor.Visible = true;

                int rowIndex = Convert.ToInt32(e.CommandArgument); // Obtiene el índice de la fila que se seleccionó


                string[] Solicitud =SolicitudesR.traersolicitud(rowIndex).Split(';');


                //Tabla del estudiante 
                DataTable tablaestudiante = new DataTable();

                tablaestudiante.Columns.Add("NombreEstudiante", typeof(string));
                tablaestudiante.Columns.Add("Apellido1", typeof(string));
                tablaestudiante.Columns.Add("Apellido2", typeof(string));
                tablaestudiante.Columns.Add("Correo", typeof(string));
                tablaestudiante.Columns.Add("NumeroTelefono", typeof(string));

                DataRow fila1 = tablaestudiante.NewRow();
                fila1["NombreEstudiante"] = Solicitud[0];
                fila1["Apellido1"] = Solicitud[1];
                fila1["Apellido2"] = Solicitud[2];
                fila1["Correo"] = Solicitud[3];
                fila1["NumeroTelefono"] = Solicitud[4];

                tablaestudiante.Rows.Add(fila1);



                GridView2.DataSource = tablaestudiante;
                GridView2.DataBind();




                //Tabla de la solicitud 
                DataTable tablasolicitud = new DataTable();


                tablasolicitud.Columns.Add("Carrera", typeof(string));
                tablasolicitud.Columns.Add("FechaHoraEnvio", typeof(string));
                tablasolicitud.Columns.Add("FechaHoraRespuesta", typeof(string));
                tablasolicitud.Columns.Add("NombreFuncionario", typeof(string));
                tablasolicitud.Columns.Add("ApellidosFuncionario", typeof(string));

                DataRow fila2 = tablasolicitud.NewRow();
                fila2["Carrera"] = Solicitud[7];
                fila2["FechaHoraEnvio"] = Solicitud[5];
                fila2["FechaHoraRespuesta"] = Solicitud[6];
                fila2["NombreFuncionario"] = Solicitud[9];
                fila2["ApellidosFuncionario"] = Solicitud[10];

                tablasolicitud.Rows.Add(fila2);

                GridView3.DataSource = tablasolicitud;
                GridView3.DataBind();






            }
            else
            {
                contenedor.Visible = false;
            }
        }





    }
}