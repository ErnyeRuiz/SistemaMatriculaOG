<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_DirCarrera.Master" AutoEventWireup="true" CodeBehind="PP_DirCarrera.aspx.cs" Inherits="SistemaMatriculaOG.Pages.PP_DirCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- Aqui viene el contenido de la pagina --%>
    <div style="text-align:center;">
        <h1>¡Bienvenido!</h1>
        <div>
            <asp:Label ID="lblNombre" style="font-size:40px;color:darkblue" runat="server" Text="Nombre"></asp:Label>
        </div>
        <h1>Director de carrera</h1>
        <div>
            <asp:Label ID="lblCarrera" style="font-size:40px;color:darkblue" runat="server" Text="Carrera"></asp:Label>
        </div>
    </div>
</asp:Content>
