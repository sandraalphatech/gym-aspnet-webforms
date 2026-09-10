<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="Gym.Forgot" %>

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
            <h2>RECUPERAÇÃO DE SENHA</h2>
        </div>

        <div class="form-group mb-3">
            <label for="bd_email">Email</label>
            <asp:TextBox ID="bd_email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_email" runat="server" ControlToValidate="bd_email" ErrorMessage="Introduza o seu email." CssClass="text-danger"> </asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group mb-3">
            <label for="bd_novasenha"> Palavra-passe</label>
            <asp:TextBox ID="bd_novasenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Nova Palavra-Passe"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_novasenha" runat="server" ControlToValidate="bd_novasenha" ErrorMessage="Introduza a nova palavra-passe." CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group mb-3">
                <label for="bd_repetirsenha">Repetir palavra-passe</label>
            <asp:TextBox  ID="bd_repetirsenha"  runat="server"  CssClass="form-control"  TextMode="Password"  placeholder="Repita a Nova Palavra-Passe"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_repetirsenha" runat="server" ControlToValidate="bd_repetirsenha" ErrorMessage="Repita a nova palavra-passe." CssClass="text-danger"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="CV_valid" runat="server" ControlToCompare="bd_novasenha" ControlToValidate="bd_repetirsenha" Operator="Equal" Type="String" ErrorMessage="As palavras-passe não coincidem." CssClass="text-danger"></asp:CompareValidator>
        </div>
        
        
        <div class="d-grid mt-3">
            <asp:Button ID="btnAlterar" runat="server" Text="ALTERAR SENHA" CssClass="btn" OnClick="btnAlterar_Click" />
        </div>

        <div class="text-center mt-3">
            <asp:Label ID="lblEmailErro" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        </div>

        <div class="text-center mt-3">
            <asp:Label ID="lblSucesso" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            <asp:HyperLink ID="hl_Login" runat="server" NavigateUrl="~/Login.aspx" Visible="false">Clique aqui para fazer Login</asp:HyperLink>
        </div>
        <div class="text-center mt-4">
            <p><asp:HyperLink ID="hl_Voltar" runat="server" NavigateUrl="~/Login.aspx" Visible="true">Voltar</asp:HyperLink></p>
        </div>

    </div>

</form>

</body>
</html>