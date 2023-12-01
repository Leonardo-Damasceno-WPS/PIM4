<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PIM.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home</title>
    <link href="home.css" rel="stylesheet" />
    <script>
        function confirmLogout() {
            var confirmLogout = confirm("Esta de acordo que deseja sair?");
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
            <a href="User.aspx">Minhas informações</a>
            <br>
            <a href="#" onclick="confirmLogout();">Sair</a>
        </nav>
    </form>
    <div class="logo">
    PAYFLOW
</div>
    
</body>
</html>
