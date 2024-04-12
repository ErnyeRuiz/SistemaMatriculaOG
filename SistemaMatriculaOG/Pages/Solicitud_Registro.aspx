<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitud_Registro.aspx.cs" Inherits="SistemaMatriculaOG.Pages.Solicitud_Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro de usuario</title>
    <%-- Bootstrap --%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <%-- Jquery && Toastr --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</head>
<body>

    <form id="form1" style="margin-left: 22%; margin-top: 2%;" runat="server">
        <%-- Informacion sobre el formulario del login --%>

        <div class="bg-primary" style="color: white; margin-left: 5%; width: 60%; border-radius: 10px">
            <div style="text-align: center; margin-top: 2%;">
                <h1>Registro de usuario</h1>
            </div>

            <div style="margin-left: 35%;">
                <div style="padding-bottom: 2%;">
                    <img src="../Img/logo.png" style="width: 50%; height: 50%; border-radius: 27px; padding-top: 2%" />
                </div>
            </div>


            <%-- Informacion del usuario --%>
            <div class="row">
                <div style="width: 200px; margin-left: 25%">
                    <div style="text-align: center;">
                        <asp:Label ID="lblCedula" Style="font-size: 20px;" runat="server" Text="Identificación(Cédula)"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtCedula" Style="font-size: 20px; width: 200px;" runat="server" MaxLength="15" onkeypress="return validarLetras(event);" placeholder="(Obligatorio)"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 200px; margin-left: 2%">
                    <div style="text-align: center;">
                        <asp:Label ID="lblnombre" Style="font-size: 20px;" runat="server" Text="Nombre"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtNombre" Style="font-size: 20px; width: 200px;" runat="server" onkeypress="return validarLetras2(event);" MaxLength="15" placeholder="(Obligatorio)"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div style="width: 200px; margin-left: 25%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label1" Style="font-size: 20px;" runat="server" Text="Apellido 1"></asp:Label>
                    </div>
                    <div style="text-align: center">
                        <asp:TextBox ID="txtapellido1" Style="font-size: 20px; width: 200px;" runat="server" onkeypress="return validarLetras2(event);" placeholder="(Obligatorio)" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 200px; margin-left: 2%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label2" Style="font-size: 20px;" runat="server" Text="Apellido 2"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtapellido2" Style="font-size: 20px; width: 200px;" runat="server" onkeypress="return validarLetras2(event);" placeholder="(Obligatorio)" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div style="width: 200px; margin-left: 25%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label3" Style="font-size: 20px;" runat="server" Text="Nacionalidad"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtNacionalidad" Style="font-size: 20px; width: 200px;" runat="server" onkeypress="return validarLetras2(event);" placeholder="(Obligatorio)" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 200px; margin-left: 2%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label4" Style="font-size: 20px;" runat="server" Text="Teléfono"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtTelefono" Style="font-size: 20px; width: 200px;" runat="server" onkeypress="return validarNumeros(event);" placeholder="(Opcional)" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div style="width: 200px; margin-left: 25%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label5" Style="font-size: 20px;" runat="server" Text="Correo electrónico"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtCorreo" Style="font-size: 20px; width: 200px;" runat="server" placeholder="(Obligatorio)" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 200px; margin-left: 2%">
                    <div style="text-align: center;">
                        <asp:Label ID="Label6" Style="font-size: 20px;" runat="server" Text="Fecha nacimiento"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtFechaNac" type="date" Style="font-size: 20px; width: 200px;" runat="server" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div style="width: 70%; margin-left: 20%; margin-top: 2%;">
                    <div style="margin-left: 5%">
                        <asp:DropDownList ID="lstCarreras" class="btn btn-info dropdown-toggle dropdown-toggle-split" Style="font-size: 20px; color: white; width: 250px" runat="server"></asp:DropDownList>
                        <asp:Label ID="Label7" Style="font-size: 20px;" runat="server" Text="(Obligatorio)"></asp:Label>
                    </div>
                </div>
            </div>

            <%-- Boton de registro --%>
            <div class="row" style="margin-top: 2%; padding-bottom: 2%;">
                <div style="width: 120px; margin-right: 2%; margin-left: 33%">
                    <asp:Button Class="btn btn-info" Style="color: white; font-size: 20px;" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" Text="Registrarse" />
                </div>
                <div style="width: 200px;">
                    <a href="Login.aspx" class="btn btn-info" style="color: white; font-size: 20px;" runat="server">Inicio de sesión</a>
                </div>
            </div>

        </div>

    </form>
</body>

<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
<%-- Script de restriccion de entradas --%>

<script type="text/javascript">
    function validarLetras(event) {
        var key = event.keyCode || event.which;
        var tecla = String.fromCharCode(key);
        var letras = /^[A-Za-z0-9\s\-]+$/;

        if (!tecla.match(letras) && key !== 8) {
            event.preventDefault();
        }
    }
</script>

<script type="text/javascript">
    function validarLetras2(event) {
        var key = event.keyCode || event.which;
        var tecla = String.fromCharCode(key);
        var letras = /^[A-Za-z\sñáéíóú]+$/;

        if (!tecla.match(letras) && key !== 8) {
            event.preventDefault();
        }
    }
</script>

<script type="text/javascript">
    function validarNumeros(event) {
        var key = event.keyCode || event.which;
        var tecla = String.fromCharCode(key);
        var numeros = /^[0-9]+$/;

        if (!tecla.match(numeros) && key !== 8) {
            event.preventDefault();
        }
    }
</script>



</html>
