using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class _1 : System.Web.UI.Page
    {

        Negocio.SolicitudgraduacionAprobadas SolicitudesR = new Negocio.SolicitudgraduacionAprobadas();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Entidades.SolicitudesGraduacion> solicitudes = new List<Entidades.SolicitudesGraduacion>();
            if (!IsPostBack)
            {


                SolicitudesR = new Negocio.SolicitudgraduacionAprobadas();
                List<Entidades.TipoGraduacion> ListaTiposOG= SolicitudesR.CargarTiposOG();

                if (Session["Usuario"] != null
                  )
                {
                    Entidades.Usuarios direc = (Entidades.Usuarios)(Session["Usuario"]);

                    if (direc.IdRol != 3)
                    {
                        Response.Redirect("Logout.aspx");
                    }
                    Entidades.DirectoresCarrera Dir = SolicitudesR.TraerDirector(direc.Cedula);

                    solicitudes = SolicitudesR.ObtenerSolicitudesAprobadas(Convert.ToInt32(Dir._CarreraDirectorC));

                }

                else
                {
                    Response.Redirect("Logout.aspx");
                }

                DataTable dt=new DataTable();
                dt.Columns.Add("IdSolicitudGraduacion", typeof(string));
                dt.Columns.Add("CedulaEstudiante", typeof(string));
                dt.Columns.Add("FechaHoraEnvio", typeof(string));
                dt.Columns.Add("FechaHoraRespuesta", typeof(string));
                dt.Columns.Add("Tipo graduación", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                foreach (Entidades.SolicitudesGraduacion sol in solicitudes)
                {
                    DataRow row= dt.NewRow();
                    
                    row["IdSolicitudGraduacion"] = sol.IdSolicitudGraduacion;
                    row["CedulaEstudiante"] = sol.CedulaEstudiante;
                    row["FechaHoraEnvio"] = sol.FechaHoraEnvio;
                    row["FechaHoraRespuesta"] = sol.FechaHoraRespuesta;
                    row["Tipo graduación"] = ListaTiposOG.Find(T => T.IdTipoGraduacion == sol.IdTipoG).NombreTipoG;
                    row["Estado"] = "Aprobada";

                    dt.Rows.Add(row);
                    
                }


                



                GridViewSolicitudes.DataSource = dt;
                GridViewSolicitudes.DataBind();
            }
        }

        protected void GridViewSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar") // Verifica si el comando es "Editar"
            {

                if (Session["Usuario"] != null
                 )
                {
                    Entidades.Usuarios direc = (Entidades.Usuarios)(Session["Usuario"]);

                    if (direc.IdRol != 3)
                    {
                        Response.Redirect("Logout.aspx");
                    } 
                    Entidades.DirectoresCarrera Dir = SolicitudesR.TraerDirector(direc.Cedula);
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }


                contenedor.Visible = true;

                int rowIndex = Convert.ToInt32(e.CommandArgument); // Obtiene el índice de la fila que se seleccionó


                string[] Solicitud = SolicitudesR.traersolicitud(rowIndex).Split(';');


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