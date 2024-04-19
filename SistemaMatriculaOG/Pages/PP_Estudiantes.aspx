<%@  Page Async="true" Title="Principal - Estudiantes" Language="C#" MasterPageFile="~/Pages/Master_Estudiantes.Master" AutoEventWireup="true" CodeBehind="PP_Estudiantes.aspx.cs" Inherits="SistemaMatriculaOG.Pages.PP_Estudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- Aqui viene el contenido de la pagina --%>
    <div style="text-align:center;">
        <h1>¡Bienvenido!</h1>
        <div>
            <asp:Label ID="lblNombreEstudiante" style="font-size:40px;color:darkblue" runat="server" Text="Nombre"></asp:Label>
        </div>
        <h1>Estudiante</h1>
    </div>
</asp:Content>
