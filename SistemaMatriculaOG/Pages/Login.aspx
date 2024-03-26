<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaMatriculaOG.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de sesión</title>
    <%-- Bootstrap --%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <%-- Jquery && Toastr --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

</head>
<body>
    <form id="form1" style="text-align: center;margin-left:20%;margin-top:5%;" runat="server">
        <%-- Informacion sobre el formulario del login --%>
        <div class="bg-primary" style="color:white; margin-left: 5%; width: 60%;border-radius:10px">
            <div style="padding-bottom:2%">
                <img src="../Img/logo.png" style="width:50%;height:50%;border-radius:27px;padding-top:2%"/>
            </div>
            <div>
                <asp:Label ID="lblCedula" style="font-size:20px;" runat="server" Text="Cédula"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtCedula" style="font-size:20px;" runat="server" MaxLength="15"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCotrasenia" style="font-size:20px;" runat="server" Text="Contraseña"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtcontrasenia" Type="password" style="font-size:20px;" runat="server" MaxLength="16"></asp:TextBox>
            </div>

            <div class="row" style="margin-top:2%;padding-bottom:2%;">
                <div style="width:150px;margin-right:2%;margin-left:30%">
                    <asp:Button Class="btn btn-info" Style="color: white;font-size:20px;" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" Text="Inicio de sesión" />
                </div>
                <div style="width:150px;">
                    <a href="Solicitud_Registro.aspx" class="btn btn-info" style="color: white;font-size:20px;" runat="server">Registrarse</a>
                </div>
            </div>
            <div style="padding-bottom:2%">
                <a class="" style="color:white;font-size:20px;" href="#.aspx">¿Recuperar contraseña?</a>
            </div>

        </div>
    </form>
</body>

<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>


</html>
