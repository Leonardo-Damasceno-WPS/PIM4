<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="PIM4.WebForm1" %>

<!DOCTYPE html>
<html>
<head>
    <title>Pesquisar Funcionário</title>
</head>
<body>
    <h1>Procurar Funcionário</h1>
    <form runat="server">
        <asp:TextBox ID="txtNomeFuncionario" runat="server" />
        <asp:Button ID="btnProcurarFuncionario" runat="server" Text="Procurar Funcionário" OnClick="btnProcurarFuncionario_Click" />

        <br />
        <br />

        <h2>Resultado da Busca:</h2>
        <asp:GridView ID="gridViewTrabalhador" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="NomeCompleto" HeaderText="Nome do Funcionário" />
                <asp:TemplateField HeaderText="Ação">
                    <ItemTemplate>
                        <asp:Button ID="btnConsultarDados" runat="server" Text="Consultar Dados" OnClick="btnConsultarDados_Click" CommandArgument='<%# Eval("NomeCompleto") %>' />
                        <asp:Button ID="btnGerarHolerite" runat="server" Text="Gerar Holerite" OnClick="btnGerarHolerite_Click" CommandArgument='<%# Eval("NomeCompleto") %>' />
                        <asp:Button ID="btnAlterarfuncionario" runat="server" Text="Alterar dados" OnClick="btnAlterarfuncionario_Click" CommandArgument='<%# Eval("NomeCompleto") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <br />

        <h2>Sobre o Funcionário:</h2>
        <asp:GridView ID="gridViewHolerite" runat="server" AutoGenerateColumns="true">
        </asp:GridView>
        
    </form>
</body>
</html>
