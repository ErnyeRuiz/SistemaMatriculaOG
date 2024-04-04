<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioContrasenia.aspx.cs" Inherits="SistemaMatriculaOG.Pages.CambioContrasenia" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cambio de contraseña</title>
    <%-- Bootstrap --%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <%-- Jquery && Toastr --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

</head>
<body>
    <form id="form1" style="text-align: center; margin-left: 05%; margin-top: 10%;" runat="server">
        <%-- Informacion sobre el formulario del login --%>
        <div class="bg-primary" style="color: white; margin-left: 20%; width: 50%; border-radius: 10px">
            <h1>Cambio de contraseña</h1>

            <div class="row mt-2">
                <div style="text-align: end; width: 53%;font-size:20px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre completo:"></asp:Label>
                </div>
                <div style="width: 47%; text-align: left;font-size:20px">
                    <asp:Label ID="Dato1" runat="server" Text="asdsada asd asdasd"></asp:Label>
                </div>
            </div>

            <div class="row mt-1">
                <div style="text-align: end; width: 53%;font-size:20px">
                    <asp:Label ID="Label1" runat="server" Text="Cédula del estudiante:"></asp:Label>
                </div>
                <div style="width: 47%; text-align: left;font-size:20px">
                    <asp:Label ID="Dato2" runat="server" Text="56782534612"></asp:Label>
                </div>
            </div>

            <div>
                <asp:Label ID="lblContranueva" Style="font-size: 20px;" runat="server" Text="Nueva contraseña"></asp:Label>
                <div>
                    <asp:TextBox ID="txtPassN" Type="password" Style="font-size: 20px;" runat="server" MaxLength="15"></asp:TextBox>
                </div>
                <%-- Validacion --%>
                <div id="validacion1" runat="server" visible="false">
                    <asp:Label ID="lblValidacion1" style="font-size:20px;color:orangered;" runat="server" Text="validacion1"></asp:Label>
                </div>
                
            </div>

            <div>
                <asp:Label ID="lblConfirmacionCotrasenia" Style="font-size: 20px;" runat="server" Text="Confirmación contraseña"></asp:Label>
                <div>
                    <asp:TextBox ID="txtPassN2" Type="password" Style="font-size: 20px;" runat="server" MaxLength="16"></asp:TextBox>
                </div>
                <%-- Validacion --%>
                <div id="validacion2" runat="server" visible="false">
                    <asp:Label ID="lblValidacion2" style="font-size:20px;color:orangered;" runat="server" Text="validacion2"></asp:Label>
                </div>
            </div>


            <div style="display: flex; justify-content: center;; margin-top: 2%;padding-bottom:2%">
                <div style="width: 150px;">
                    <asp:Button Class="btn btn-info" Style="color: white; font-size: 20px;" ID="btnCambiar" OnClick="btnCambiar_Click" runat="server" Text="Confirmar" />
                </div>
            </div>
        </div>
    </form>
</body>

<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>


</html>
