<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registo_form.aspx.cs" Inherits="Gym.Registo_form" MaintainScrollPositionOnPostBack="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet"/>


<link rel="stylesheet" href="css/owl.carousel.min.css"/>
<link rel="stylesheet" href="css/bootstrap.min.css"/>
<link rel="stylesheet" href="css/style.css"/>
    
    <title>GYM</title>

</head>

<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="container">
                <div class="row">
           
<div class="col-md-6"><img src="img/logo.png" alt="Imagem" class="img-fluid"/>
    <asp:Button ID="btn_list" runat="server" Text="Acessar Registo de Clientes" CssClass="btn btn-block btn-primary" Height="70px" Width="325px" OnClick="btn_list_Click" />
</div>
                    <div class="col-md-6 contents">
                        <div class="row justify-content-center">

                            <div class="col-md-8">
                                <div class="mb-4">
                                    <h3>REGISTAR CLIENTE</h3>
                                    <p class="mb-4"> Preencha os dados do cliente para efetuar o registo.</p>
                                </div>        
                             <div>

                         <strong> <label for="td_nome">Nome</label></strong>
                           <div class="form-group">
                               <asp:TextBox ID="tb_nome" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>

                         <strong><label for="td_nascimento">Data de Nascimento</label></strong>
                          <div class="form-group">
                          <label for="td_nascimento"></label><asp:TextBox ID="tb_nascimento" runat="server" TextMode="Date" CssClass="form-control" Width="463px"></asp:TextBox>
                          </div>

                          <strong><label for="td_email">E-mail</label> </strong>     
                          <div class="form-group">
                              <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" Width="347px"></asp:TextBox>
                          </div>

                           <strong><label for="td_contacto">Contacto</label></strong>
                           <div class="form-group">
                               <asp:TextBox ID="tb_contacto" runat="server" TextMode="Phone" CssClass="form-control" Width="298px"></asp:TextBox>
                           </div>

                          <strong><label for="td_peso">Peso (kg)</label></strong>
                          <div class="form-group">
                              <asp:TextBox ID="tb_peso" runat="server" CssClass="form-control"></asp:TextBox>  
                          </div>

                          <strong><label for="td_altura">Altura (cm)</label></strong>
                          <div class="form-group">
                              <asp:TextBox ID="tb_altura" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>

                         <strong> <label for="ddl_objetivo">Objetivo</label></strong>
                          <div class="form-group">
                              <asp:DropDownList ID="ddl_objetivo" runat="server" CssClass="form-control ddl-objetivo" DataSourceID="objetivos" DataTextField="NomeObjetivo" DataValueField="IdObjetivo" AppendDataBoundItems="true" Height="25px" Width="478px">
                                    <asp:ListItem Value="" Selected="True">Escolha um Objetivo</asp:ListItem>
                              </asp:DropDownList> 

                              <asp:SqlDataSource ID="objetivos" runat="server" ConnectionString="<%$ ConnectionStrings:objetivos_lista %>" 
                                  ProviderName="<%$ ConnectionStrings:objetivos_lista.ProviderName %>" 
                                  SelectCommand="SELECT * FROM [Objetivos]">
                              </asp:SqlDataSource>
                          </div>

                         <div class="Btncont">
                             <asp:Button ID="btn_insert" runat="server" Text="Registar via Insert" CssClass="btn btn-block btn-primary" Height="44px" Width="220px" OnClick="btn_insert_Click" />
                             <asp:Button ID="btn_insertSP" runat="server" Text="Registar via SP" CssClass="btn btn-block btn-primary" Height="44px" Width="220px" OnClick="btn_insertSP_Click" />
                         </div>

                         <br />
                         <br />

                         <asp:Label ID="lbl_msgm" runat="server" CssClass="mensagem-sucesso" Text="Cliente registado com sucesso!" Visible="False" Font-Bold="True" Width="393px"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="lista_clientes" runat="server" visible="false" class="lista-clientes">

    <h3>Lista de Clientes</h3>

    <asp:GridView 
        ID="GridView1" 
        runat="server"
        AllowPaging="True"
        AutoGenerateColumns="False"
        DataKeyNames="IdCliente"
        DataSourceID="listadeclientes"
        CssClass="tabela-clientes"
        GridLines="None">

        <Columns>
            <asp:BoundField DataField="IdCliente" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
            <asp:BoundField DataField="Peso" HeaderText="Peso" />
            <asp:BoundField DataField="Altura" HeaderText="Altura (cm)" />
            <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" />
        </Columns>

    </asp:GridView>

     <asp:SqlDataSource 
        ID="listadeclientes" 
        runat="server"
        ConnectionString="<%$ ConnectionStrings:GymConnectionString2 %>"
        SelectCommand="SELECT * FROM Clientes">
    </asp:SqlDataSource>
    <br />
    <br />
        </div>
    </form>
</body>
</html>
