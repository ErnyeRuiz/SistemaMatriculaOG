<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Funcionarios.Master" AutoEventWireup="true" CodeBehind="Responder_SolicitudesOG.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Responder_SolicitudesOG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <div class="modal fade" id="modalVerSolicitud" tabindex="-1" role="dialog" aria-labelledby="modalVerSolicitudLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalVerSolicitudLabel">Ver Empleado</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtIdEmpleado">Id Empleado:</label>
                        <asp:TextBox ID="txtIdEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="txtApellido">Apellidos:</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="txtFechaNacimiento">Fecha de nacimiento:</label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="txtFechaIngreso">Fecha de ingreso:</label>
                        <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="txtDepatarmento">Departamento:</label>
                        <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control"></asp:TextBox>                                        
                        <label for="txtPuesto">Puesto:</label>
                        <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>                                        
                        <label for="txtSalario">Salario:</label>
                        <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control"></asp:TextBox>
                        <div style="margin-top:15px"></div>
                        <asp:Button CssClass="btn btn-primary" ID="btnPruebasConocimiento" runat="server" Text="Pruebas de conocimiento" />                                        
                        <asp:Button CssClass="btn btn-info" ID="btnPruebasPsicometricas" runat="server" Text="Pruebas psicometricas" />                                        
                        <div style="margin-top:10px"></div>
                        <asp:Button CssClass="btn btn-secondary" ID="btnCursos" runat="server" Text="Cursos" />
                        <asp:Button CssClass="btn btn-light" ID="btnCurriculum" runat="server" Text="Ver curriculum" />
                    
                        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<asp:Button ID="btnModificar" runat="server" Text="Confirmar Insert" CssClass="btn btn-primary" OnClick="btnConfirmarInsert_Click" OnClientClick="cerrarModalYActualizar()" />--%>
                </div>
            </div>
        </div>
    </div>
</div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
</asp:Content>
