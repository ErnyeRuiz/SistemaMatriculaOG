using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Responder_SolicitudesOG : System.Web.UI.Page
    {
        List<Carreras> carreras = new List<Carreras>();
        List<VistaSolicitudesPendientes> listaSolicitudesPendientes = new List<VistaSolicitudesPendientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarreras();
                CargarSolicitudes();
            }
        }
        private void CargarSolicitudes()
        {
            listaSolicitudesPendientes = Negocio.SolicitudesGraduacion.VerSolicitudesOGPendientes();

            rptSolicitudesOG.DataSource = listaSolicitudesPendientes;

            rptSolicitudesOG.DataBind();
        }
        private void CargarCarreras()
        {
            carreras = Negocio.SolicitudesGraduacion.VerCarreras();

            drpCarrera.Items.Add(new ListItem("Todas"));

            if (carreras.Count > 0)
            {
                foreach (var carrera in carreras)
                {
                    ListItem listItem = new ListItem(carrera._NombreCarrera);
                    drpCarrera.Items.Add(listItem);
                }
            }
        }
        //Evento de seleccion de carrera 
        protected void drpCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaSolicitudesPendientes = Negocio.SolicitudesGraduacion.VerSolicitudesOGPendientes();
            if (drpCarrera.Text != "Todas")
            {
                var filtroCarrera = listaSolicitudesPendientes.Where(solicitud => solicitud.Carrera == drpCarrera.Text)
                    .ToList();
                rptSolicitudesOG.DataSource = filtroCarrera;
                rptSolicitudesOG.DataBind();
            }
            else
            {
                rptSolicitudesOG.DataSource = listaSolicitudesPendientes;
                rptSolicitudesOG.DataBind();
            }

        }
        //protected void btnSeleccionar_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#modalVerSolicitud').modal('show');", true);
        //}
        protected void rptSolicitudesOG_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$('#modalVerSolicitud').modal('show');", true);
            }
        }
    }
}