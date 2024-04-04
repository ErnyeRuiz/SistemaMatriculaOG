<%@ Page Title="Envío de solicitudes de opción de graduación" Language="C#" MasterPageFile="~/Pages/Master_Estudiantes.Master" AutoEventWireup="true" CodeBehind="Solicitud_OG.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Solicitud_OG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/RegistroSolicitudOG.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerOG1">
        <div class="containerOG2">

            <div style="text-align: center; margin-top: 2%;">
                <h1>Envío de solicitud de opción de graduación</h1>
            </div>

            <div style="margin-left: 35%;">
                <div style="padding-bottom: 2%;">
                    <img src="../Img/logo.png" style="width: 50%; height: 50%; border-radius: 27px; padding-top: 2%" />
                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-3">
                    <asp:Label AssociatedControlID="txtCedula" runat="server">Cédula</asp:Label>
                    <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" ReadOnly="true">305330534</asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label AssociatedControlID="txtNombreApellidos" runat="server" ReadOnly="true">Nombre y apellidos</asp:Label>
                    <asp:TextBox ID="txtNombreApellidos" CssClass="form-control" runat="server" ReadOnly="true">Ernye Ruiz Cerdas</asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:Label AssociatedControlID="txtCarrera" ID="lblCarrera" runat="server" Text="Carrera"></asp:Label>
                    <asp:TextBox ID="txtCarrera" CssClass="form-control" runat="server" ReadOnly="true">Tecnologias de informacion</asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label AssociatedControlID="txtCorreo" ID="lblCorreo" runat="server" Text="Correo electrónico"></asp:Label>
                    <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" ReadOnly="true" TextMode="email">ernye1010gmail.com</asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label AssociatedControlID="txtNumero" ID="lblTelefono" runat="server" Text="Número de telefono"></asp:Label>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" ReadOnly="true">64526120</asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:Label AssociatedControlID="drpOpcion" ID="lblOpcion" runat="server">Opción de graduación</asp:Label>
                    <asp:DropDownList style="background-color: #f4c284; font-size: 14px;" CssClass="form-control" ID="drpOpcion" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 2%; padding-bottom: 2%;">
                <div style="width: 120px; margin-right: 2%; margin-left: 33%">
                    <asp:Button Class="btn btn-info" Style="color: white; font-size: 20px;" ID="Button1" runat="server" Text="Registrarse" />
                </div>
                <div style="width: 200px;">
                    <a href="Login.aspx" class="btn btn-info" style="color: white; font-size: 20px;" runat="server">Inicio de sesión</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
