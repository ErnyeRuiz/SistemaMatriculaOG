<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Funcionarios.Master" AutoEventWireup="true" CodeBehind="Responder_SolicitudesOG.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Responder_SolicitudesOG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/responderSolicitudesOG.css" rel="stylesheet" />
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container">
  <h2 style="text-align:center;">Solicitudes de Opcion de Graduación Pendientes</h2>
  <p></p>    
    <div >
        <asp:DropDownList id="drpCarrera" runat="server" OnSelectedIndexChanged="drpCarrera_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </div>
  <table class="table table-hover">
    <thead>
      <tr>
        <th>Carrera</th>
        <th>Nombre</th>
        <th>Apellidos</th>
        <th>Cedula</th>
        <th>Tipo</th>
        <th>Fecha de envío</th>
      </tr>
    </thead>
    <tbody>        
        <ContentTemplate>
            <asp:Repeater OnItemCommand="rptSolicitudesOG_ItemCommand" ClientIDMode="Static" ID="rptSolicitudesOG" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%#Eval("Carrera")%></td>
                      <td><%#Eval("Nombre")%></td>
                      <td><%#Eval("Apellidos")%></td>
                      <td><%#Eval("Cedula")%></td>
                      <td><%#Eval("Tipo")%></td>
                      <td><%#Eval("Fecha")%></td>
                      <td>
                          <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-primary"
                         CommandName="Ver" CommandArgument='<%# Eval("IdSolicitud") %>'/>
                      </td>
                        
                    </tr>
                </ItemTemplate>
            
            </asp:Repeater>     
        </ContentTemplate>              
    </tbody>
  </table>
   <!-- Modal -->
<div class="modal fade" id="miModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="modalLabel">
            <asp:Label ID="lblTituloModal" runat="server" Text="Solicitud Seleccionada"></asp:Label>
        </h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:Label Visible="false" ID="lblIdSolicitud" runat="server" Text="Label"></asp:Label>
        <h4><asp:Label ID="lblDatosEstudiante" runat="server" Text="Datos de estudiante"></asp:Label></h4>
        <h6><asp:Label ID="lblNombreEstudiante" runat="server" Text="Nombre y apellidos del estudiante"></asp:Label></h6>
        <h6><asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label></h6>
        <h6><asp:Label ID="lblCorreo" runat="server" Text="Correo electronico"></asp:Label></h6>
        <h6><asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label></h6>
        <h6><asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label></h6>
        <h4><asp:Label ID="lblDetallesSolicitud" runat="server" Text="Detalles de solicitud"></asp:Label></h4>
        <h6><asp:Label ID="lblTipo" runat="server" Text="Tipo de solicitud"></asp:Label></h6>
        <h6><asp:Label ID="lblFechaHoraEnvio" runat="server" Text="Fecha y hora de envio"></asp:Label></h6>
        <h6><asp:Label ID="lblEstadoSolicitud" runat="server" Text="Carrera"></asp:Label></h6>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
         <asp:Button OnClick="btnRechazar_Click" ID="btnRechazar" CssClass="btn btn-danger" runat="server" Text="Rechazar" />
         <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />        
      </div>
    </div>
  </div>
</div>
<div class="modal fade" id="modalMotivo" tabindex="-1" role="dialog" aria-labelledby="modallabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="">
            <asp:Label ID="Label1" runat="server" Text="Motivo de rechazo"></asp:Label>
        </h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:TextBox ID="txtMotivo" runat="server"></asp:TextBox>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
         <asp:Button OnClick="btnConfirmar_Click" ID="btnConfirmar" CssClass="btn btn-success" runat="server" Text="Confirmar"/>        
      </div>
    </div>
  </div>
</div>
</div>
    
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
