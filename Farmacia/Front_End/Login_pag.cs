using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.ConexaoBanco;

namespace Front_End
{
    public class Executar
    {
        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.SetCompatibleTextRenderingDefault(false);
        //     Application.Run(new Login());
        // }
    }

    public class Login : Form
    {
        private Label lblLogin, lblSenha;
        private TextBox txtLogin, txtSenha;
        private Button btnLogin;
        private Panel panelContainer;

        public Login()
        {
            this.Size = new Size(550, 500);
            this.Text = "Login";
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackgroundImage = Image.FromFile(@"C:\Users\willdanthealaman\Documents\GitHub\Farmacia-windowsForms\Farmacia\Front_End\farmaciatela.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold);

            panelContainer = new Panel
            {
                Size = new Size(300, 200),
                BackColor = Color.FromArgb(200, Color.White),
                Anchor = AnchorStyles.None
            };
            panelContainer.Location = new Point((this.ClientSize.Width - panelContainer.Width) / 2, (this.ClientSize.Height - panelContainer.Height) / 2);
            this.Controls.Add(panelContainer);

            lblLogin = new Label { Text = "Login:", Font = fontePadrao, AutoSize = true, Location = new Point(20, 20) };
            txtLogin = new TextBox { Width = 200, Location = new Point(80, 20) };

            lblSenha = new Label { Text = "Senha:", Font = fontePadrao, AutoSize = true, Location = new Point(20, 60) };
            txtSenha = new TextBox { Width = 200, Location = new Point(80, 60), PasswordChar = '*' };

            btnLogin = new Button { Text = "Login", Width = 100, Location = new Point(100, 100) };
            btnLogin.Click += new EventHandler(btnLogin_Click);

            panelContainer.Controls.Add(lblLogin);
            panelContainer.Controls.Add(txtLogin);
            panelContainer.Controls.Add(lblSenha);
            panelContainer.Controls.Add(txtSenha);
            panelContainer.Controls.Add(btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cpf = txtLogin.Text;
            string senha = txtSenha.Text;

            using (var context = new Conexao())
            {
                try
                {
                    var usuario = context.Usuarios.FirstOrDefault(u => u.cpf == cpf && u.senha == senha);

                    if (usuario != null)
                    {
                        MessageBox.Show("Login bem-sucedido!");
                        this.Hide();

                        Form proximaTela = usuario.cargo switch
                        {
                            "Gerente" => new GerenteForm(),
                            "Farmaceutico" => new FarmaceuticoForm(),
                            "Atendente" => new AtendenteForm(),
                            _ => null
                        };

                        proximaTela?.Show();
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
