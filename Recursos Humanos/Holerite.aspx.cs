using System;
using System.Data;
using System.Data.SqlClient;

namespace SuaApp
{
    public partial class Holerite : System.Web.UI.Page
    {
        protected string nomeCompleto = string.Empty;
        protected string CPF = string.Empty;
        protected string localizacao = string.Empty;
        protected string dataAdmissaoDate = string.Empty;
        protected string cargoOcupacao = string.Empty;
        protected string salarioAtual = string.Empty;
        protected string NomeEmpresa = string.Empty;
        protected string CNPJEmpresa = string.Empty;
        protected string EnderecoEmpresa = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Nome"] != null)
                {
                    nomeCompleto = Server.UrlDecode(Request.QueryString["Nome"]);

                    string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;";

                    string sqlCpfQuery = @"
                        SELECT
                            A.NumeroCPF AS CPF,
                            A.Localizacao,
                            A.DataAdmissao,
                            A.CargoOcupacao,
                            A.SalarioAtual
                        FROM
                            Trabalhador A
                        WHERE
                            A.NomeCompleto = @NomeFunc
                    ";

                    string sqlEmpresaQuery = @"
                        SELECT
                            B.NomeEmpresa,
                            B.NumeroCNPJ,
                            B.Localizacao
                        FROM
                            EmpresaContratante B
                        WHERE 
                            B.NomeEmpresa IN (
                                SELECT B2.NomeEmpresa
                                FROM EmpresaContratante B2
                                INNER JOIN Trabalhador A ON B2.id_empresa = B.id_empresa
                                WHERE A.NomeCompleto = @NomeFunc
                            )
                    ";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmdCpf = new SqlCommand(sqlCpfQuery, connection))
                        using (SqlCommand cmdEmpresa = new SqlCommand(sqlEmpresaQuery, connection))
                        {
                            cmdCpf.Parameters.AddWithValue("@NomeFunc", nomeCompleto);
                            cmdEmpresa.Parameters.AddWithValue("@NomeFunc", nomeCompleto);

                            connection.Open();
                            CPF = cmdCpf.ExecuteScalar() as string;
                            using (SqlDataReader readerTrabalhador = cmdCpf.ExecuteReader())
                            {
                                if (readerTrabalhador.Read())
                                {
                                    localizacao = readerTrabalhador["Localizacao"].ToString();
                                    DateTime dataAdmissao = Convert.ToDateTime(readerTrabalhador["DataAdmissao"]);
                                    dataAdmissaoDate = readerTrabalhador["DataAdmissao"].ToString();
                                    cargoOcupacao = readerTrabalhador["CargoOcupacao"].ToString();
                                    salarioAtual = readerTrabalhador["SalarioAtual"].ToString();
                                }
                            }
                            using (SqlDataReader readerEmpresa = cmdEmpresa.ExecuteReader())
                            {
                                if (readerEmpresa.Read())
                                {
                                    NomeEmpresa = readerEmpresa["NomeEmpresa"].ToString();
                                    CNPJEmpresa = readerEmpresa["NumeroCNPJ"].ToString();
                                    EnderecoEmpresa = readerEmpresa["Localizacao"].ToString();
                                }
                            }

                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}
