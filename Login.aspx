<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PIM.TelaIncial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <link href="telainicial.css" rel="stylesheet" />
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginContainer">
            <h1>Login</h1>
            <asp:Panel ID="centralPanel" runat="server">
                <asp:TextBox ID="usuarioTextBox" runat="server" CssClass="inputField" placeholder="Usuario"></asp:TextBox>
                <br />
                <asp:TextBox ID="senhaTextBox" runat="server" TextMode="Password" CssClass="inputField" placeholder="Senha"></asp:TextBox>
                <br />
                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="loginButton" />
                <br />
                <asp:Label ID="resultLabel" runat="server" CssClass="errorMessage" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
