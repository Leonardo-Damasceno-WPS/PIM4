<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Holerite.aspx.cs" Inherits="SuaApp.Holerite" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <%--<meta charset="UTF-8">--%>
    <title>Holerite</title>
    <link href="holer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="hs">
            <div class="holerite-cabecalho">
                <h1>Holerite do Trabalhador</h1>
            </div>

            <!-- Exibir informações do funcionário -->
            <div class="informacao">
                <h2>Informações do Funcionário</h2>
                <ul>
                    <li><strong>Funcionário:</strong> <%= nomeCompleto %></li>
                    <li><strong>CPF:</strong> <%= CPF %></li>
                    <li><strong>Endereço:</strong> <%= localizacao %></li>
                    <li><strong>Data de Admissão:</strong> <%= dataAdmissaoDate %></li>
                    <li><strong>Cargo/Função:</strong> <%= cargoOcupacao %></li>
                    <li><strong>Salário Base:</strong> <%= salarioAtual %></li>
                </ul>
            </div>

            <!-- Exibir informações da empresa -->
            <div class="enterprise">
                <h2>Informações da Empresa</h2>
                <ul>
                    <li><strong>Nome da Empresa:</strong> <%= NomeEmpresa %></li>
                    <li><strong>CNPJ:</strong> <%= CNPJEmpresa %></li>
                    <li><strong>Endereço:</strong> <%= EnderecoEmpresa %></li>
                </ul>
            </div>

            <!-- Rodapé da página -->
            <div class="rodape">
                <p>Holerite gerado no dia: <%= DateTime.Now.ToString("dd/MM/yyyy") %></p>
            </div>
        </div>
    </form>
</body>
</html>
