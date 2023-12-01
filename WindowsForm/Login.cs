using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM
{
    public partial class LoginForm : LoginForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            //obtendo valor das caixas de texto "Matricula" e "Senha"
            string usuarioValue = this.usuarioTextBox.Text;
            string senhaValue=this.senhaTextBox.Text;

            //Preparando conexão com banco de dados usando o SqlConnection:
            using (SqlConnection conexao = Conexao.conectar())
            {
                string query = "SELECT CredenciaisAcesso FROM Usuario WHERE Usuario = @usuario AND senha = @senha";
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@usuario", usuarioValue);
                cmd.Parameters.AddWithValue("@senha", senhaValue);

                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    //Autenticação bem-sucedida
                    MessageBox.Show("Login bem-sucedido!", "Autentificação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    //autenticação Mau-sucedida
                    MessageBox.Show("Usuário e/ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
