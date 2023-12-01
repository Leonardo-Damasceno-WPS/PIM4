using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PIM4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcurarFuncionario_Click(object sender, EventArgs e)
        {
            string nome = txtNomeFuncionario.Text; // Obtém o nome do funcionário a ser buscado

            // String de conexão com o banco de dados (substitua pelos seus próprios detalhes de conexão)
            string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta SQL para buscar funcionários por nome
                string sqlQuery = "SELECT NomeCompleto FROM Trabalhador WHERE NomeCompleto LIKE @Nome";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%"); // Use '%' para corresponder a qualquer parte do nome

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dt.Columns.Add("@Nome", typeof(string));

                        // Vincula o DataTable ao GridView para exibir os resultados

                        //if (dt.Columns.Contains("@Nome"))
                        //{
                        //    gridViewTrabalhador.DataSource = dt;
                        //    gridViewTrabalhador.DataBind();
                        //}
                        //else
                        //{
                            
                        //    // Lide com a situação em que a coluna 'Nome' não está presente
                        //}
                        gridViewTrabalhador.DataSource = dt;
                        gridViewTrabalhador.DataBind();
                    }
                }
            }
        }

        protected void gridViewTrabalhador_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnConsultarDados = new Button();
                btnConsultarDados.Text = "Consultar Dados";
                btnConsultarDados.CommandName = "ConsultarDados";
                btnConsultarDados.CommandArgument = ((DataRowView)e.Row.DataItem)["NomeCompleto"].ToString();
                btnConsultarDados.Click += new EventHandler(btnConsultarDados_Click);

                e.Row.Cells[1].Controls.Add(btnConsultarDados);
            }
        }

        protected void btnConsultarDados_Click(object sender, EventArgs e)
        {
            Button btnDadosClicado = (Button)sender;
            string nomeFuncionario = btnDadosClicado.CommandArgument;

            // Configura a string de conexão com o banco de dados
            string connectionString = "Server=DESKTOP-PS9UV7U;Database = pim4_alternativo;Integrated Security=True;User Id=Alan;Password=;";

            // Consulta SQL para buscar informações do funcionário por nome
            string sqlQuery = "SELECT NomeCompleto, NumeroCPF, Localizacao, DataAdmissao, CargoOcupacao, SalarioAtual FROM Trabalhador WHERE NomeCompleto = @Nome";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nomeFuncionario);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        gridViewHolerite.DataSource = dt;
                        gridViewHolerite.DataBind();
                    }
                }
            }
        }
        protected void btnGerarHolerite_Click(object sender, EventArgs e)
        {
            Button btnHoleriteClicado = (Button)sender;
            string nomeFuncionario = btnHoleriteClicado.CommandArgument;

            // Redireciona para a página "Holerite.aspx" e passa o nome como parâmetro na URL
            Response.Redirect("Holerite.aspx?Nome=" + Server.UrlEncode(nomeFuncionario));
        }
        protected void btnAlterarfuncionario_Click(object sender, EventArgs e)
        {
            Button btnAlterarfuncionario = (Button)sender;
            string nomeFuncionario = btnAlterarfuncionario.CommandArgument;

            // Redireciona para a página "Holerite.aspx" e passa o nome como parâmetro na URL
            Response.Redirect("AtualizarDados.aspx?Nome=" + Server.UrlEncode(nomeFuncionario));
        }

    }
}