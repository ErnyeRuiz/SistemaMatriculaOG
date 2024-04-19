<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Egresados.Master" AutoEventWireup="true" CodeBehind="PP_Egresados.aspx.cs" Inherits="SistemaMatriculaOG.Pages.PP_Egresados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- Aqui viene el contenido de la pagina --%>
    <div style="text-align:center;">
        <h1>¡Bienvenido!</h1>
        <div>
            <asp:Label ID="lblNombreEstudiante" style="font-size:40px;color:darkblue" runat="server" Text="Hernán Fernández García"></asp:Label>
        </div>
        <h1>Estudiante Egresado</h1>
    </div>
</asp:Content>
