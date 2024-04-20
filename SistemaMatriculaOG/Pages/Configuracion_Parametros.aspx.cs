using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG.Pages
{
    public partial class Configuracion_Parametros : System.Web.UI.Page
    {
        Negocio.ConfiguracionParametros config = new Negocio.ConfiguracionParametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) {
                Entidades.ParametrosSistema param = config.TraerParametrosSistema();
                
                lbldato1.Text = param.FechaHoraInicio.ToShortDateString();
                lbldato2.Text = param.FechaHoraInicio.ToString("HH:mm tt");
                lbldato3.Text = param.FechaHoraCierre.ToShortDateString();
                lbldato4.Text = param.FechaHoraCierre.ToString("HH:mm tt");

                //Datos del funcionario que realizó el ultimo cambio
                try
                {
                    string[] data = config.NombreCompletoFuncionarioUltimoCambio().Split(';');
                    DateTime FechaHoraUltimoCambio = DateTime.Parse(data[1]);
                    lblNombreFuncionario.Text = data[0];
                    lblFechaUltimo.Text ="Fecha de último cambio: "+ FechaHoraUltimoCambio.ToShortDateString();
                    lblHoraUltimo.Text ="Hora de último cambio: "+ FechaHoraUltimoCambio.ToString("HH:mm tt");
                } 
                catch
                {
                    lblNombreFuncionario.Text = "No registrado";
                    lblFechaUltimo.Text = "Fecha de último cambio: " + "No disponible";
                    lblHoraUltimo.Text = "Hora de último cambio: " + "No disponible";
                }
                

            }

            if (Session["Mensaje"] != null)
            {
                //Mensaje en pantalla
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.success('{Convert.ToString(Session["Mensaje"])}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                Session["Mensaje"] = null;
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            Entidades.Usuarios funcionario=new Entidades.Usuarios();
            //Validacion del usuario
            if (Session["Usuario"] != null)
            {
                funcionario = (Entidades.Usuarios)(Session["Usuario"]);
                if (funcionario.IdRol!=4) {
                    Response.Redirect("Logout.aspx");
                }

            }
            else {
                Response.Redirect("Logout.aspx");
            }
            //Validacion de los campos
            bool PermitirCambio = true;
            string FechaI=txtFechaApertura.Text;
            string HoraI=txtHoraApertura.Text;
            string FechaC=txtFechaCierre.Text;
            string HoraC=txtHoraCierre.Text;

            //Asignar variables por default
            Validacion1.Visible = false;
            Validacion2.Visible = false;
            Validacion3.Visible = false;
            Validacion4.Visible = false;


            if (FechaI.Equals(""))
            {
                Validacion1.Visible = true;
                PermitirCambio = false;
            }
            if (HoraI.Equals(""))
            {
                Validacion2.Visible = true;
                PermitirCambio = false;
            }
            if (FechaC.Equals(""))
            {
                Validacion3.Visible = true;
                PermitirCambio = false;
            }
            if (HoraC.Equals(""))
            {
                Validacion4.Visible = true;
                PermitirCambio = false;
            }

            if (PermitirCambio==true) {
                //Asignacion de variables de apertura
                DateTime FechaHoraInicio= DateTime.Parse(FechaI + " " + HoraI);
                //Asignacion de variables de cierre
                DateTime FechaHoraCierre = DateTime.Parse(FechaC + " " + HoraC);
                //Realiza la modificacion en la BD
                config.ModificarParametrosSistema(FechaHoraInicio,FechaHoraCierre,funcionario.Cedula);

                Session["Mensaje"] = "Cambios realizados exitosamente.";
                Response.Redirect("Configuracion_Parametros.aspx");
            }


        }
    }
}