using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Front_End
{
    public class Executar
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class Login : Form
    {
        private Label lblLogin, lblSenha;
        private TextBox txtLogin, txtSenha;
        private Button btnLogin;

        public Login()
        {
            this.Size = new Size(550, 500);
            this.Text = "Login";
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold);

            lblLogin = new Label { Text = "Login:", Location = new Point(20, 20), Font = fontePadrao, AutoSize = true };
            txtLogin = new TextBox { Location = new Point(150, 20), Width = 200 };

            lblSenha = new Label { Text = "Senha:", Location = new Point(20, 50), Font = fontePadrao, AutoSize = true };
            txtSenha = new TextBox { Location = new Point(150, 50), Width = 200, PasswordChar = '*' };

            btnLogin = new Button { Text = "Login", Location = new Point(150, 80), Width = 100 };
            btnLogin.Click += new EventHandler(btnLogin_Click);

            this.Controls.AddRange(new Control[]
            {
                lblLogin, txtLogin,
                lblSenha, txtSenha,
                btnLogin
            });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cpf = txtLogin.Text;
            string senha = txtSenha.Text;

            using (var context = new AppDbContext())
            {
                try
                {
                    var usuario = context.Usuarios.FirstOrDefault(u => u.Cpf == cpf && u.Senha == senha);

                    if (usuario != null)
                    {
                        MessageBox.Show("Login bem-sucedido!");

                        this.Hide();

                        if (usuario.Cargo == "Gerente")
                        {
                            var formGerente = new GerenteForm();
                            formGerente.Show();
                        }
                        if (usuario.Cargo == "Farmaceutico")
                        {
                            var formFarmaceutico = new FarmaceuticoForm();
                            formFarmaceutico.Show();
                        }
                        if (usuario.Cargo == "Atendente")
                        {
                            var formAtendente = new AtendenteForm();
                            formAtendente.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar conectar ao banco de dados: " + ex.Message);
                }
            }
        }
    }
}
