<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Estudiantes.Master" AutoEventWireup="true" CodeBehind="SolicitudOG.aspx.cs" Inherits="SistemaMatriculaOG.Pages.SolicitudOG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Enviar solicitud de opcion de graduacion</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="mb-3 row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Cedula</label>
            <div class="col-sm-10">               
                <asp:TextBox ID="txtCedula" CssClass="form-control-plaintext" ReadOnly="true" runat="server">305330534</asp:TextBox>
            </div>

            <label for="staticEmail" class="col-sm-2 col-form-label">Nombre y apellidos</label>
            <div class="col-sm-10">              
                <asp:TextBox ID="txtNombreApellidos" CssClass="form-control-plaintext" ReadOnly="true" runat="server">Ernye Ruiz Cerdas</asp:TextBox>
            </div>

            <label for="staticEmail" class="col-sm-2 col-form-label">Carrera</label>
            <div class="col-sm-10">                    
                <asp:TextBox ID="txtCarrera" CssClass="form-control-plaintext" ReadOnly="true" runat="server">TI</asp:TextBox>
            </div>

            <label for="staticEmail" class="col-sm-2 col-form-label">Correo</label>
            <div class="col-sm-10">                  
                <asp:TextBox ID="txtCorreo" CssClass="form-control-plaintext" ReadOnly="true" runat="server">ernye1010@gmail.com</asp:TextBox>
            </div>

            <label for="staticEmail" class="col-sm-2 col-form-label">Telefono</label>
            <div class="col-sm-10">                  
                <asp:TextBox ID="txtTelefono" CssClass="form-control-plaintext" ReadOnly="true" runat="server">64526120</asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Opción de graduación</label>
            <div class="dropdown">
                <asp:DropDownList CssClass="form-control" ID="drpOG" runat="server"></asp:DropDownList>                
            </div>
        </div>
    </div>  
</asp:Content>
