using System;
using System.Data.SqlClient;

namespace PIM
{
    public partial class Perfilaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    string usuario = Session["Usuario"].ToString();
                    string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sqlQuery = @"
                            SELECT
                                A.NomeCompleto,
                                A.NumeroCPF,
                                A.Localizacao,
                                C.Usuario,
                                A.CargoOcupacao,
                                A.SalarioAtual,
                                A.DataAdmissao
                            FROM
                                Trabalhador A
                            JOIN
                                CredenciaisAcesso C ON A.id_trabalhador = C.id_credencial
                            WHERE
                                C.Usuario = @Usuario
                        ";
                        ;
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@usuario", usuario);
                            connection.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lblNome.Text = "Nome: " + reader["NomeCompleto"].ToString();
                                    lblCPF.Text = "CPF: " + reader["NumeroCPF"].ToString();
                                    lblEndereco.Text = "Endereço: " + reader["Localizacao"].ToString();
                                    lblUsuario.Text = "ID: " + reader["Usuario"].ToString();
                                    lblCargo.Text = "Cargo/Ocupação: " + reader["CargoOcupacao"].ToString();
                                    lblSalario.Text = "Salário: " + reader["SalarioAtual"].ToString();
                                    DateTime dataAdmissao = Convert.ToDateTime(reader["DataAdmissao"]);
                                    lblDataAdmissao.Text = "Data de Admissão: " + dataAdmissao.ToString("dd/MM/yyyy");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}
