<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtualizarDados.aspx.cs" Inherits="PIM.Alterar_dados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alterar os Dados</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Alteração de Dados do Funcionário</h1>
            
            <div>
                <label for="txtID">ID do Funcionário:</label>
                <input type="text" id="txtID" runat="server" />
            </div>
            
            <div>
                <label for="txtNovoSalario">Novo Salário:</label>
                <input type="text" id="txtNovoSalario" runat="server" />
            </div>
            
            <div>
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
            </div>
            
            <div>
                <asp:Label ID="lblMensagem" runat="server" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
