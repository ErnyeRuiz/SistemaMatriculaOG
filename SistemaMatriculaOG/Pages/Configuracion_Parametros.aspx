<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Funcionarios.Master" AutoEventWireup="true" CodeBehind="Configuracion_Parametros.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Configuracion_Parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-primary row" style="width: 70%; color: white; border-radius: 20px; margin-left: 15%; margin-top: 2%">
        <%-- Vista de las configuraciones del sistema --%>
        <div style="width: 50%; text-align: center">
            <h3>Configuración actual de parámetros del sistema</h3>

            <div style="font-size: 20px;">
                <div class="row">
                    <div style="width: 50%; text-align: right">
                        <asp:Label ID="lbl1" runat="server" Text="Fecha de apertura:"></asp:Label>
                    </div>
                    <div style="width: 50%; text-align: left">
                        <asp:Label ID="lbldato1" runat="server" Text="Dato1"></asp:Label>
                    </div>
                </div>
            </div>

            <div style="font-size: 20px;">
                <div class="row">
                    <div style="width: 50%; text-align: right">
                        <asp:Label ID="lbl2" runat="server" Text="Hora de apertura:"></asp:Label>
                    </div>
                    <div style="width: 50%; text-align: left">
                        <asp:Label ID="lbldato2" runat="server" Text="Dato2"></asp:Label>
                    </div>
                </div>
            </div>

            <div style="font-size: 20px;">
                <div class="row">
                    <div style="width: 50%; text-align: right">
                        <asp:Label ID="lbl3" runat="server" Text="Fecha de cierre:"></asp:Label>
                    </div>
                    <div style="width: 50%; text-align: left">
                        <asp:Label ID="lbldato3" runat="server" Text="Dato3"></asp:Label>
                    </div>
                </div>
            </div>

            <div style="font-size: 20px;">
                <div class="row">
                    <div style="width: 50%; text-align: right">
                        <asp:Label ID="lbl4" runat="server" Text="Hora de cierre:"></asp:Label>
                    </div>
                    <div style="width: 50%; text-align: left">
                        <asp:Label ID="lbldato4" runat="server" Text="Dato4"></asp:Label>
                    </div>
                </div>
            </div>

            <div style="text-align: center;padding-bottom:2%;">
                <h5>Nombre del funcionario que realizó el ultimo cambio:</h5>
                <div>
                    <asp:Label ID="lblNombreFuncionario" style="font-size:20px;" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblFechaUltimo" style="font-size:20px;" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblHoraUltimo" style="font-size:20px;" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
        <%-- Controladores de parametros --%>
        <div style="width: 50%; text-align: center">
            <h3>Configurar parámetros</h3>
            <div style="padding-bottom: 5%">
                <div class="row" style="justify-content: center">
                    <div style="text-align: right; width: 35%">
                        <h5>Fecha de apertura</h5>
                        <asp:TextBox ID="txtFechaApertura" type="date" placeholder="Obligatorio" Style="font-size: 20px" runat="server"></asp:TextBox>
                    </div>
                    <div style="text-align: left; width: 35%">
                        <h5>Hora de apertura</h5>
                        <asp:TextBox ID="txtHoraApertura" type="time" placeholder="Obligatorio" Style="font-size: 20px; margin-left: 10%" runat="server"></asp:TextBox>
                    </div>

                </div>

                <%-- Validaciones --%>
                <div id="Validacion1" runat="server" visible="false">
                    <asp:Label runat="server" Style="color: orangered; font-size: 20px;" Text="No se ha rellenado el campo de fecha de inicio”"></asp:Label>
                </div>
                <div id="Validacion2" runat="server" visible="false">
                    <asp:Label runat="server" Style="color: orangered; font-size: 20px;" Text="No se ha rellenado el campo de hora de inicio"></asp:Label>
                </div>

                <div class="row" style="justify-content: center">
                    <div style="text-align: center; width: 35%">
                        <h5>Fecha de cierre</h5>
                        <asp:TextBox ID="txtFechaCierre" type="date" placeholder="Obligatorio" Style="font-size: 20px" runat="server"></asp:TextBox>
                    </div>
                    <div style="text-align: left; width: 35%">
                        <h5>Hora de cierre</h5>
                        <asp:TextBox ID="txtHoraCierre" type="time" placeholder="Obligatorio" Style="font-size: 20px; margin-left: 10%" runat="server"></asp:TextBox>
                    </div>

                </div>

                <%-- Validaciones --%>

                <div id="Validacion3" runat="server" visible="false">
                    <asp:Label runat="server" Style="color: orangered; font-size: 20px;" Text="No se ha rellenado el campo de fecha de cierre"></asp:Label>
                </div>
                <div id="Validacion4" runat="server" visible="false">
                    <asp:Label runat="server" Style="color: orangered; font-size: 20px;" Text="No se ha rellenado el campo de hora de cierre"></asp:Label>
                </div>

                <div style="justify-content: center; margin-top: 2%">
                    <asp:Button ID="btnAplicar" runat="server" class="btn btn-info" OnClick="btnAplicar_Click" Style="color: white; font-size: 20px;" Text="Aplicar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
