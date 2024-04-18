<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Funcionarios.Master" AutoEventWireup="true" CodeBehind="RegistrosolicituddeOGFuncionarios.aspx.cs" Inherits="SistemaMatriculaOG.Pages.RegistrosolicituddeOGFuncionarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-primary text-white" style="margin-top: 5%; width: 50%; border-radius: 20px; margin-left: 25%">
        <div class="text-center mb-4">
            <h1>Agregar Solicitud de Graduación</h1>
        </div>
        <!-- Campos para agregar la solicitud de graduación -->
        <div class="mb-3 text-center" style="width: 300px; margin: 0 auto;">
            <label for="txtCedulaEstudiante" class="form-label" style="width: 100%;">Cédula del estudiante</label>
            <asp:TextBox ID="txtCedulaEstudiante" runat="server" Style="width: 100%;" CssClass="form-control" required="true" />
        </div>


        <div class="mb-3 text-center" style="width: 300px; margin: 0 auto;">
            <label for="ddlOpcionGraduacion" class="form-label">Opción de Graduación</label>
            <asp:DropDownList ID="ddlOpcionGraduacion" runat="server" CssClass="form-control" required="true">
                <asp:ListItem Text="Seleccione una opción" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col text-center">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar solicitud" OnClick="btnAgregar_Click" Style="color: white; font-size: 20px;" CssClass="btn btn-info" />
        </div>
        <div class="col text-center" style="padding-bottom: 2%">
            <asp:Label ID="lblMensaje" runat="server" Style="color: orangered; font-size: 20px;" CssClass="form-text"></asp:Label>
        </div>

    </div>
</asp:Content>
