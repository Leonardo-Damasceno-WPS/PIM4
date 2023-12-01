using System;
using System.Data.SqlClient;

namespace PIM
{
    public partial class Alterar_dados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //Carregamento
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;"; // Substitua pela sua connection string

            int idFuncionario = int.Parse(txtID.Value); // ID do funcionário
            decimal novoSalario = decimal.Parse(txtNovoSalario.Value); // Novo salário

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Trabalhador SET SalarioAtual = @NovoSalario WHERE id_trabalhador = @Worker";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NovoSalario", novoSalario);
                    command.Parameters.AddWithValue("@Worker", idFuncionario);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensagem.Text = "Atualização realizada!";
                    }
                    else
                    {
                        lblMensagem.Text = "Nenhum dado foi atualizado.";
                    }
                }
            }
        }
    }
}
