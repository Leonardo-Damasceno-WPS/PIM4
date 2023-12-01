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
using PIM;
using PIM_Biblioteca;


namespace PIM
{
    public partial class LoginForm : LoginForm
    {
        string usuarioValue;
        string senhaValue;
        private void CentralizePanel()
        {
            centralPanel.Left = (this.ClientSize.Width - centralPanel.Width) / 2;
            centralPanel.Top = (this.ClientSize.Height - centralPanel.Height) / 2;
        }
        public LoginForm()
        {
            InitializeComponent();
            CentralizePanel();
        }
        public string Usuario
        {
            get { return this.usuarioTextBox.Text; }
        }
        public void LoginBTN_Click(object sender, EventArgs e)
        {
            //obtendo valor das caixas de texto "Usuario" e "Senha"
            usuarioValue = this.usuarioTextBox.Text;
            senhaValue = this.senhaTextBox.Text;

            //Preparando a conexão com banco de dados usando o SqlConnection:
            using (SqlConnection conexao = Conn.conectar())
            {
                string query = "select Usuario from CredenciaisAcesso where Usuario = @usuario AND Senha = @senha";
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@usuario", usuarioValue);
                cmd.Parameters.AddWithValue("@senha", senhaValue);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    //string Usuario = Convert.ToString(result);
                    //bool admin = Convert.ToBoolean(result);

                    //Autenticação bem-sucedida
                    MessageBox.Show("Login realizado com sucesso!", "Autentificação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;

                    //Chamando a tela principal
                    //FormPrincipal formprincipal = new FormPrincipal(this, admin)
                    //{
                    //    Admin = admin

                    //};
                    //MessageBox.Show(Convert.ToString(usuario), "login");
                    //formprincipal.FormClosing += FormPrincipal_FormClosing;
                    //formprincipal.Show();

                    //Fechando tela de login
                    this.Hide();
                    Conexao.Desconectar(conexao);

                }
                else
                {
                    //autenticação Mau-sucedida
                    MessageBox.Show("Usuário e/ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CentralizePanel();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            CentralizePanel();

        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CentralizePanel();

        }

        private void usuarioLabel_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usuarioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void centralPanel_Paint(object sender, PaintEventArgs e)
        {

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
