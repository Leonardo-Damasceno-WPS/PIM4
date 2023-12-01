using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_Biblioteca;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using PIM;

namespace PIM
{


    public partial class FormPrincipal : Form
    {
        //private SqlCommand cmd;
        public bool Admin { get; set; }
        public LoginForm loginForm { get; set; }
        //public string Usuario { get; }

        TabPage myTabPage;
        //string usuario  = LoginForm.Usuario;

        public FormPrincipal(LoginForm loginfrm, bool admin)
        {
            InitializeComponent();

            this.loginForm = loginfrm;
            this.Admin = admin;
            myTabPage = AdmimPage;



            // valida se possui um usuário de admnistrador
            if (Admin == false) //caso usuário não seja administrador a aba Gerenciamento será removida do formulário pricipal
            {
                tabControl.TabPages.Remove(myTabPage);
                //MessageBox.Show("useradmim");
            }




            //MessageBox.Show(Convert.ToString(IsUserAdmin), "principal");
            FormPrincipal_Load();


        }

        //public FormPrincipal(LoginForm loginForm, string usuario)
        //{
        //    this.loginForm = loginForm;
        //    Usuario = Usuario;
        //}

        private void FormPrincipal_Load()
        {
            string usuario = loginForm.Usuario;
            Controles.Atualiza_Info_Colab(usuario, perfil_Nome, perfil_CPF, perfil_Endereco, perfil_Usuario, perfil_Cargo, perfil_Salario, perfil_DataAdmissao, PerfilPage);
            Controles.Atualiza_Info_Colab(usuario, Alt_Nome, Alt_CPF, Alt_Endereco, Alt_Usuario, Alt_Cargo, Alt_Salário, Alt_DataAdmissao, ManutencaoUser);
            Alt_User_Btn.Enabled = false;
            Controles.TravarHolerite(Holerite_RazaoSocial, Holerite_CNPJ, Holerite_EnderecoEmpregador, Holerite_NomeFuncionario, Holerite_Usuario, Holerite_Funcao, Holerite_CPF, Holerite_DataAdmissao, Holerite_Endereco, Holerite_SalarioFixo, Holerite_Competencia, Holerite_SalarioBruto, Holerite_SalarioLiquido, Holerite_TotalProventos, Holerite_DescontoTotal, Holerite_CalculoHE, Holerite_Transporte, Holerite_INSS, Holerite_FGTS, Holerite_PronventosHE, Gerar_Holerite_BTN, Label_CampoObrigatório1, Label_CampoObrigatório2);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void filtrar_HS_btn_Click(object sender, EventArgs e)
        {
            string inicio = inicio_HS_txtbox.Text.Trim();
            string fim = fim_HS_txtbox.Text.Trim();
            string funcionario = loginForm.Usuario;
            DataTable dt = new DataTable();

            if (inicio_HS_txtbox.Text.Trim() == "")
            {
                inicio = "1900-01-01";
            }
            if (fim_HS_txtbox.Text.Trim() == "")
            {
                fim = "2999-12-31";
            }
            try
            {
                using (SqlConnection connect = Conexao.conectar())
                {
                    //connect.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_trabalhador, NumeroCPF, DataAdmissao, CargoOcupacao, SalarioAtual, MesAno, SalarioBruto, SalarioLiquido, BeneficiosTotais, HorasExtras, DescontosTotais, Transporte, DescontoINSS, DescontoFGTS" +
                        "FROM InformacoesFolhaPagamento WHERE MesAno BETWEEN @inicio AND @fim AND id_trabalhador = @usuario", connect))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        cmd.Parameters.AddWithValue("@usuario", funcionario);
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fim", fim);
                        adapter.Fill(dt);
                    }
                    dgv_HS.DataSource = dt;
                    dgv_HS.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.AllCells;
                    Conexao.Desconectar(connect);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_HS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void filtrar_Holerite_btn_Click(object sender, EventArgs e)
        {
            string usuario = loginForm.Usuario;
            //Checa se o campo está completo
            if (data_TxtBox_Holerite.Text == "")
            {
                MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                data_TxtBox_Holerite.Focus();
            }

            string holeriteData = data_TxtBox_Holerite.Text;
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {

                using (SqlConnection conectar = Conexao.conectar())
                {
                    string info_query_user = "SELECT TOP 1 id_trabalhador, NomeCompleto, NumeroCPF, Localizacao, DataAdmissao, CargoOcupacao, SalarioAtual FROM Trabalhador WHERE NomeCompleto = @usuario;";
                    using (SqlCommand cmd1 = new SqlCommand(info_query_user, conectar))
                    {
                        cmd1.Parameters.AddWithValue("@usuario", usuario);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd1))
                        {
                            adapter.Fill(dt1);
                        }
                    }
                    this.dgv_Colab.DataSource = dt1;
                    dgv_Colab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    string info_query_money = "SELECT TOP 1 id_credencial, NomeCompleto, NumeroCPF, Localizacao, DataAdmissao, CargoOcupacao, SalarioAtual FROM Trabalhador WHERE Usuario = @usuario";
                    using (SqlCommand cmd2 = new SqlCommand(info_query_money, conectar))
                    {
                        cmd2.Parameters.AddWithValue("@usuario", usuario);
                        cmd2.Parameters.AddWithValue("@data", holeriteData);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
                        {
                            adapter.Fill(dt2);
                        }
                    }
                    this.dgv_Info_Money.DataSource = dt2;
                    dgv_Info_Money.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch
            {

            }
        }

        private void perfil_Nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void Alt_Dados_Checkbox_CheckedChanged(object sender, EventArgs e)
        {

            if (Alt_Dados_Checkbox.Checked)
            {
                Alt_Endereco.ReadOnly = false;
                Alt_Cargo.ReadOnly = false;
                Alt_Salário.ReadOnly = false;
                Alt_User_Btn.Enabled = true;
            }
            else
            {
                Alt_Endereco.ReadOnly = true;
                Alt_Cargo.ReadOnly = true;
                Alt_Salário.ReadOnly = true;
                Alt_User_Btn.Enabled = false;
            }

        }

        private void Pesq_User_Btn_Click(object sender, EventArgs e)
        {
            string new_localizacao = Alt_Endereco.Text;
            string new_CargoOcupacao = Alt_Cargo.Text;
            string new_salario = Alt_Salário.Text;
            string nome = Alt_Nome.Text;
            string id_usuario = Controles.GetIDUser(nome);
            string usuario = Controles.UseUser(nome);
            if (Alt_Dados_Checkbox.Checked)
            {
                Controles.UpdateUser(id_usuario, new_localizacao, new_CargoOcupacao, new_salario);
                Controles.Atualiza_Info_Colab(usuario, Alt_Nome, Alt_CPF, Alt_Endereco, Alt_Usuario, Alt_Cargo, Alt_Salário, Alt_DataAdmissao, ManutencaoUser);
                FormPrincipal_Load();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = Busca_User.Text;
            string usuario = Controles.UseUser(nome);

            if (usuario != null)
            {
                Controles.Atualiza_Info_Colab(usuario);
                Alt_User_Btn.Enabled = false;
                Alt_Dados_Checkbox.Checked = false;
            }
        }

        private void Pesquisar_Geracao_Holerite_Click(object sender, EventArgs e)
        {
            string usuario = Pesquisa_Gerar_Holerite.Text;
            if (Pesquisa_Gerar_Holerite != null)
            {
                Controles.PesquisarHolerite(usuario);
            }
        }

        private void Titulo_Demonstrativo_Holerite_Click(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Gerar_Holerite_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Holerite_Usuario.Text == null)
            {
                Gerar_Holerite_CheckBox.Checked = false;
                MessageBox.Show("Selecione um usuário antes de gerar a folha de pagamento!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (Gerar_Holerite_CheckBox.Checked)
                {
                    Gerar_Holerite_BTN.Enabled = true;
                    Holerite_CalculoHE.ReadOnly = false;
                    Holerite_Competencia.ReadOnly = false;
                    Label_CampoObrigatório1.Enabled = true;
                    Label_CampoObrigatório2.Enabled = true;
                }
                else
                {
                    Gerar_Holerite_BTN.Enabled = false;
                    Holerite_CalculoHE.ReadOnly = true;
                    Holerite_Competencia.ReadOnly = true;
                    Label_CampoObrigatório1.Enabled = false;
                    Label_CampoObrigatório2.Enabled = true;
                }
            }
        }

        private void Gerar_Holerite_BTN_Click(object sender, EventArgs e)
        {
            string userid = Controles.GetIDUser(Holerite_NomeFuncionario.Text);
            string idusuario = Controles.GetIDusuario(Holerite_Usuario.Text);
            string idempregador = Controles.GetIDEmpregador(Holerite_CNPJ.Text);
            string competencia = Holerite_Competencia.Text;
            string salariobruto = Holerite_SalarioFixo.Text;
            string horaextra = Holerite_CalculoHE.Text;

            Controles.GerarHolerite(userid, idusuario, idempregador, competencia, salariobruto, horaextra);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Click(object sender, EventArgs e)
        {

        }
    }
}
