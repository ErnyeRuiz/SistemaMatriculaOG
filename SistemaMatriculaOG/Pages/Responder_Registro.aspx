<%@ Page Title="Respuesta solicitudes" Language="C#" MasterPageFile="~/Pages/Master_Funcionarios.Master" AutoEventWireup="true" CodeBehind="Responder_Registro.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Responder_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/VentanaModal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-primary mt-2" style="width: 40%; color: white; margin-left: 30%; border-radius: 27px; text-align: center;">
        <h2>Respuesta de solicitudes de registro al sistema</h2>

        <div style="padding-bottom: 2%">
            <asp:DropDownList ID="lstSolicitudes" Class="btn btn-info" AutoPostBack="true" OnSelectedIndexChanged="lstSolicitudes_SelectedIndexChanged" Style="color: white" runat="server"></asp:DropDownList>
        </div>

        <div id="Contenedor" runat="server" visible="false">
            <%-- Datos Estudiante --%>
            <h3>Datos del estudiante</h3>

            <div class="row">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label1" runat="server" Text="Cédula del estudiante:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="Dato1" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label2" runat="server" Text="Nombre completo:"></asp:Label>
                </div>
                <div style="width: 47%; text-align: left">
                    <asp:Label ID="Dato2" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label3" runat="server" Text="Nacionalidad:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="Dato3" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label4" runat="server" Text="Correo electrónico:"></asp:Label>
                </div>
                <div style="width: 47%; text-align: left">
                    <asp:Label ID="Dato4" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label5" runat="server" Text="Número de teléfono:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="Dato5" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label6" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="Dato6" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="Label7" runat="server" Text="Carrera del estudiante:"></asp:Label>
                </div>
                <div style="width: 47%; text-align: left">
                    <asp:Label ID="Dato7" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <%-- Informacion solicitud --%>
            <h3>Datos de la solicitud</h3>
            <div class="row">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="lblFechaS" runat="server" Text="Fecha de solicitud:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="DatoS1" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="lblHoraS" runat="server" Text="Hora de solicitud:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="DatoS2" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado de la solicitud:"></asp:Label>
                </div>
                <div style="width: 30%; text-align: left">
                    <asp:Label ID="DatoS3" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <%-- Botones --%>
            <div style="width: 90%; margin: 0 auto; display: flex; justify-content: center; align-items: center; padding-bottom: 2%; padding-top: 2%;">
                <asp:Button ID="btnAprobar" Class="btn btn-success" OnClick="btnAprobar_Click" Style="width: 200px; font-size: 20px;" runat="server" Text="Aprobar Solicitud" />
                <!--Inicio de boton modal-->
                <label for="btn-modal1" class="btn btn-danger" style="width: 200px; height: 9%; margin-left: 2%; font-size: 20px;">
                    Rechazar solicitud
                </label>
                <!--Fin de Boton modal-->
            </div>
            <!--Ventana Modal-->
            <input type="checkbox" id="btn-modal1">
            <div class="container-modal1">
                <div class="content-modal1">
                    <%-- Inicio Body --%>
                    <div style="text-align: center; color: white">
                        <h3>Ingrese el motivo de rechazo de la solicitud de registro</h3>
                        <textarea id="txtMotivo" onkeypress="return validarLetras(event);" runat="server" style="resize: none; width: 600px; font-size: 20px; border-radius: 20px;"></textarea>
                        <div>
                            <asp:Button ID="btnRechazar" Class="btn btn-danger" OnClick="btnRechazar_Click" Style="font-size: 20px;" runat="server" Text="Rechazar solicitud" />
                        </div>
                    </div>
                    <%-- Fin body --%>
                    <div class="btn-cerrar1">
                    </div>
                </div>
                <label for="btn-modal1" class="cerrar-modal1"></label>
            </div>
            <%-- Ventana Modal --%>
        </div>
    </div>

    <script type="text/javascript">
    function validarLetras(event) {
        var key = event.keyCode || event.which;
        var tecla = String.fromCharCode(key);
        var letras = /^[A-Za-z\sñáéíóú]+$/;

        if (!tecla.match(letras) && key !== 8) {
            event.preventDefault();
        }
    }
    </script>
</asp:Content>
