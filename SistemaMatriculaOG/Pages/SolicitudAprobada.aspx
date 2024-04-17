<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_DirCarrera.Master" AutoEventWireup="true" CodeBehind="SolicitudAprobada.aspx.cs" Inherits="SistemaMatriculaOG.Pages._1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview-container {
            margin-top: 20px;
        }

        .gridview-header {
            background-color: #337ab7;
            color: #fff;
            font-weight: bold;
            text-align:center;
        }

        .gridview-row {
            background-color: #f9f9f9;
            text-align: center;
        }

        .gridview-footer {
            background-color: #337ab7;
            color: #fff;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Solicitudes Aprobadas</h1>

    <div class="gridview-container">
        <asp:GridView ID="GridViewSolicitudes" runat="server" AutoGenerateColumns="false" CssClass="gridview" OnRowCommand="GridViewSolicitudes_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdSolicitudGraduacion" HeaderText="ID Solicitud" />
                <asp:BoundField DataField="CedulaEstudiante" HeaderText="Cédula Estudiante" />
                <asp:BoundField DataField="FechaHoraEnvio" HeaderText="Fecha y Hora Envío" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField DataField="FechaHoraRespuesta" HeaderText="Fecha y Hora Respuestas" />
                <asp:BoundField DataField="Tipo graduación" HeaderText="Tipo de Graduacion" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Seleccionar" class="btn btn-primary" Style="color: white" CommandName="Editar" CommandArgument='<%# Eval("IdSolicitudGraduacion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="gridview-header" />
            <RowStyle CssClass="gridview-row" />
            <FooterStyle CssClass="gridview-footer" />
        </asp:GridView>

        <div id="contenedor" runat="server" visible="false">

            <h1>Informacion del estudiante</h1>

            <asp:GridView ID="GridView2" runat="server"></asp:GridView>


            <h1>Informacion de la solicitud seleccionada</h1>

            <asp:GridView ID="GridView3" runat="server"></asp:GridView>




        </div>
    </div>
</asp:Content>
