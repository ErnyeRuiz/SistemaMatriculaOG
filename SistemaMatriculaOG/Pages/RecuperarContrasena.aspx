<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="SistemaMatriculaOG.RecuperarContrasena" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
 
     <meta charset="UTF-8"/>

    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>Recuperar Contraseña</title>

 
    <%-- Bootstrap --%>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
 
    <%-- SweetAlert --%>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
 
    <script>

        function mostrarMensaje(mensaje) {

            Swal.fire({

                title: 'Mensaje',

                text: mensaje,

                icon: 'info',

                confirmButtonText: 'OK'

            });

        }

        function mostrarError(mensaje) {

            Swal.fire({

                title: 'Error',

                text: mensaje,

                icon: 'error',

                confirmButtonText: 'OK'

            });

        }

    </script>
 
 
</head>

<body>

    <form id="form1" style="text-align: center;margin-left:20%;margin-top:5%;" runat="server">

        <div class="bg-primary" style="color:white; margin-left: 5%; width: 60%;border-radius:10px">
 
            

             <div style="padding-bottom:2%">

                <img src="../Img/logo.png" style="width:250px;height:200px;border-radius:27px;padding-top:2%"/>

            </div>
 
 
             <div>

                 <h1>Recuperar Contraseña</h1>       
 
                <asp:Label ID="lblCedula" style="font-size:20px;" runat="server" Text="Ingrese su número de Cédula"></asp:Label>

            </div>

            <div>

                <asp:TextBox ID="TxtCedula" style="font-size:20px;" runat="server" MaxLength="15"></asp:TextBox>

            </div>
 
 
            <div class="row" style="margin-top:2%;padding-bottom:2%;">
 
                <div style="width:150px;margin-right:2%;margin-left:42%">

                    <asp:Button Class="btn btn-info" Style="color: white;font-size:20px;" ID="BtnConfirmar" OnClick="BtnConfirmar_Click" runat="server" Text="Confirmar" />

                </div>

            </div >
 
            
 
            <div>

                <a class="" style="color:white; font-size:20px;" href="Login.aspx">Regresar a la pantalla principal</a>

            </div>
 
        </div>

    </form>

</body>

</html>
