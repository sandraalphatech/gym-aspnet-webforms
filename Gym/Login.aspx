<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gym.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Área de Colaborador | Gym</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" />
    <link href="css/register.css" rel="stylesheet" />

</head>

<body>
<form id="form1" runat="server">
    <div class="container-register">
        <img src="img/logo.png" alt="Imagem" class="img-register"/>
        
        <div class="text-center mb-4"> 
            <h2>LOGIN DE COLABORADOR</h2>
        </div>

        <div class="form-group mb-3">
            <label for="bd_email">Email</label>
            <asp:TextBox ID="bd_email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
        </div>
        
        <div class="form-group mb-3">
            <label for="bd_senha"> Palavra-passe</label>
            <asp:TextBox ID="bd_senha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Palavra-passe"></asp:TextBox>
        </div>
        
        <asp:Label ID="lbl_msgm" runat="server" CssClass="mensagem-erro" Visible="False" Font-Bold="True"></asp:Label>
        
        <div class="d-grid mt-3">
            <asp:Button ID="btnAceder" runat="server" Text="ACEDER" CssClass="btn" OnClick="btnAceder_Click" />
        </div>
        
        <br />
        <div class="text-center mt-4">
            <p> Esqueceu sua password? <a href="Forgot.aspx" id="lbl_forgot">Clique aqui</a></p>
            <br />
            <p> Não tem uma conta? <a href="Register.aspx" id="lbl_register">Registar-se</a></p></div>

    </div>

</form>

</body>
</html>