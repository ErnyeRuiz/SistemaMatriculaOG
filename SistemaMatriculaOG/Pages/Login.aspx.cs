﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatriculaOG
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = null;

            if (Session["Mensaje"] != null){
                //Mensaje en pantalla
                string scriptalerta =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('{Convert.ToString(Session["Mensaje"])}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                Session["Mensaje"] = null;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validar el ingreso del usuario
            string cedula=txtCedula.Text.Trim();
            string contrasenia=txtcontrasenia.Text.Trim();
            if (!cedula.Equals("") && !contrasenia.Equals("")) { 
                Negocio.Login inicio=new Negocio.Login();
                if (inicio.ValidarUsuario(cedula, contrasenia).Equals("Valido")) {
                    //Trae informacion del usuario
                    Usuarios user = inicio.TraerUsuario(cedula);

                    if (user != null)
                    {
                        Session["Usuario"] = user;

                        if (user.IdRol1 == 1)
                        {
                            Response.Redirect("PP_Estudiantes.aspx");
                        }
                        else if (user.IdRol1 == 2)
                        {
                            Response.Redirect("PP_Egresados.aspx");
                        }
                        else if (user.IdRol1 == 3) 
                        {
                            Response.Redirect("PP_DirCarrera.aspx");
                        }
                        else if (user.IdRol1 == 4) 
                        {
                            Response.Redirect("PP_Registro.aspx");
                        }

                    }

                }
                else
                {
                    Session["Mensaje"] = "Datos incorrectos.";
                    Response.Redirect("Login.aspx");
                }
            }
            else{
                Session["Mensaje"] = "Datos incorrectos.";
                Response.Redirect("Login.aspx");
            }
        }
    }
}