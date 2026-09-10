<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registo.aspx.cs" Inherits="Gym.Registo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Registo de Colaborador | Gym</title>

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
            <h2>REGISTAR COLABORADOR</h2>
        </div>
        <div class="form-group mb-3">
            <label for="bd_nome">Nome completo</label>
            <asp:TextBox ID="bd_nome" runat="server" CssClass="form-control" placeholder="Nome completo"></asp:TextBox>
        </div>

        <div class="form-group mb-3">
            <label for="bd_email">Email</label>
            <asp:TextBox ID="bd_email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
        </div>
        
        <div class="form-group mb-3">
            <label for="bd_funcao">Função</label>
            <asp:TextBox ID="bd_funcao" runat="server" CssClass="form-control" placeholder="Função"></asp:TextBox>
        </div>
        
        <div class="form-group mb-3">
            <label for="bd_senha"> Palavra-passe</label>
            <asp:TextBox ID="bd_senha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Palavra-passe"></asp:TextBox>
        </div>
        
        <div class="form-group mb-3">
            <label for="bd_repetirsenha"> Confirmar palavra-passe </label>
            <asp:TextBox ID="bd_repetirsenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar palavra-passe"></asp:TextBox>
        </div>
        
        <asp:Label ID="lbl_msgm" runat="server" CssClass="mensagem-sucesso" Visible="False" Font-Bold="True"></asp:Label>
        
        <div class="d-grid mt-3">
            <asp:Button ID="btnRegistar" runat="server" Text="CRIAR CONTA" CssClass="btn" OnClick="btnRegistar_Click" />
        </div>
        
        <div class="text-center mt-4"> <p> Já tem uma conta? <a href="Login.aspx" id="lbl_login">Entrar</a></p></div>

    </div>

</form>

</body>
</html>