<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="PIM.Perfilaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Perfil</title>
    <link href="profile.css" rel="stylesheet" />
    <script>
    function confirmLogout() {
        var confirmLogout = confirm("Tem certeza que deseja sair?");
        if (confirmLogout) {
            window.location.href = "Login.aspx";
        }
    }
    </script>
    
</head>
<body>
    <form id="form1" class="menu" runat="server">
        <input type="checkbox" class="menu-fake-trigger">
        <nav class="menuStyle">
            <span></span>
            <span></span>
            <span></span>
            <a href="Home.aspx">Início</a>
            <br/>
            <a href="#" onclick="confirmLogout();">Sair</a>
        </nav>

        <!-- Exibir informações do funcionário -->
        <div class="funcionario-info">
            <h1>Informações do empregado</h1>
            <asp:Label ID="lblNome" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblCPF" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblEndereco" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblCargo" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblSalario" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblDataAdmissao" runat="server" Text=""></asp:Label><br />

        </div>
    </form>
</body>
</html>
