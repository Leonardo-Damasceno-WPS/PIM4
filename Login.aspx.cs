using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace PIM
{
    public partial class TelaIncial : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string usuarioValue = usuarioTextBox.Text;
            string senhaValue = senhaTextBox.Text;
            
            string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CredenciaisAcesso WHERE Usuario = @usuario AND Senha = @senha";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@usuario", usuarioValue);
                cmd.Parameters.AddWithValue("@senha", senhaValue);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Autenticação bem-sucedida
                        Session["Usuario"] = usuarioValue;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        // Autenticação Mau-sucedida
                        resultLabel.Text = "Usuário e/ou senha inválidos.";
                    }
                }
            }
        }
    }
}
