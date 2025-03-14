using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// #606060 #EBEBEB #233ED9
namespace Front_End
{
    public partial class GerenteForm : Form
    {
        public GerenteForm()
        {
            // InitializeComponent();
            ConfigurarInterface();
        }

        private void ConfigurarInterface()
        {
            this.Text = "Painel do Gerente";
            this.Size = new System.Drawing.Size(1000, 600);
            this.AutoSize = true;

            TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };

            // Tab 1 - Gerenciamento de Usuários
            TabPage tabUsuarios = new TabPage("Registro de Venda");
            TableLayoutPanel panelUsuarios = CriarPainelUsuarios();
            tabUsuarios.Controls.Add(panelUsuarios);

            // Tab 2 - Cadastro de Fornecedores
            TabPage tabFornecedores = new TabPage("Pesquisa e Consulta");
            TableLayoutPanel panelFornecedores = CriarPainelConsulta();
            tabFornecedores.Controls.Add(panelFornecedores);

            // Tab 3 - Relatórios
            TabPage tabRelatorios = new TabPage("Controle De Validade");
            TableLayoutPanel panelRelatorios = CriarPainelRelatorios();
            tabRelatorios.Controls.Add(panelRelatorios);

            tabControl.TabPages.Add(tabUsuarios);
            tabControl.TabPages.Add(tabFornecedores);
            tabControl.TabPages.Add(tabRelatorios);
            this.Controls.Add(tabControl);
        }

        private TableLayoutPanel CriarPainelUsuarios()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true, Name = "panelUsuarios" };
            panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

            // Controles de entrada
            Label lblNome = new Label { Text = "Nome:", Name = "lblNome" };
            panel.Controls.Add(lblNome, 0, 0);

            TextBox txtNome = new TextBox { Dock = DockStyle.Fill, Name = "txtNome" };
            panel.Controls.Add(txtNome, 1, 0);

            Label lblCodigoProduto = new Label { Text = "Código Produto:", Name = "lblCodigoProduto" };
            panel.Controls.Add(lblCodigoProduto, 0, 1);

            TextBox txtCodigoProduto = new TextBox { Dock = DockStyle.Fill, Text = "Gerente", Name = "txtCodigoProduto" };
            panel.Controls.Add(txtCodigoProduto, 1, 1);

            Label lblCpf = new Label { Text = "CPF:", Name = "lblCpf" };
            panel.Controls.Add(lblCpf, 0, 2);

            MaskedTextBox mskCpf = new MaskedTextBox { Mask = "000.000.000-00", Dock = DockStyle.Fill, Name = "mskCpf" };
            panel.Controls.Add(mskCpf, 1, 2);

            Label lblSenha = new Label { Text = "Senha:", Name = "lblSenha" };
            panel.Controls.Add(lblSenha, 0, 3);

            TextBox txtSenha = new TextBox { PasswordChar = '*', Dock = DockStyle.Fill, Name = "txtSenha" };
            panel.Controls.Add(txtSenha, 1, 3);

            // Tabela de Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableUsuarios"
            };

            // Adiciona colunas com preenchimento proporcional
            for (int i = 0; i < 4; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            Button btnInserirUsuario = new Button { Text = "Inserir Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnInserirUsuario" };
            buttonsTable.Controls.Add(btnInserirUsuario, 0, 0);

            Button btnListaUsuario = new Button { Text = "Lista Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnListaUsuario" };
            buttonsTable.Controls.Add(btnListaUsuario, 1, 0);

            Button btnAtualizarUsuario = new Button { Text = "Atualizar Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnAtualizarUsuario" };
            buttonsTable.Controls.Add(btnAtualizarUsuario, 2, 0);

            Button btnApagarUsuario = new Button { Text = "Apagar Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnApagarUsuario" };
            buttonsTable.Controls.Add(btnApagarUsuario, 3, 0);

            panel.Controls.Add(buttonsTable, 1, 4);

            DataGridView dgvUsuarios = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvUsuarios" };
            panel.Controls.Add(dgvUsuarios, 1, 5);

            return panel;
        }

        private TableLayoutPanel CriarPainelConsulta()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true, Name = "panelConsulta" };

            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableConsulta"
            };

            // Adiciona colunas com preenchimento proporcional
            buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            Label lblCodigoMedicamento = new Label { Text = "Cód do Medicamento:", Dock = DockStyle.Fill, Name = "lblCodigoMedicamento" };
            panel.Controls.Add(lblCodigoMedicamento, 0, 1);

            TextBox txtCodigoMedicamento = new TextBox { Dock = DockStyle.Fill, Name = "txtCodigoMedicamento" };
            panel.Controls.Add(txtCodigoMedicamento, 0, 2);

            Button btnPesquisar = new Button { Text = "Pesquisar", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnPesquisar" };
            buttonsTable.Controls.Add(btnPesquisar, 0, 3);

            panel.Controls.Add(buttonsTable, 0, 4);

            DataGridView dgvConsulta = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvConsulta" };
            panel.Controls.Add(dgvConsulta, 0, 5);

            return panel;
        }

        private TableLayoutPanel CriarPainelRelatorios()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true, Name = "panelRelatorios" };

            // Tabela de Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableRelatorios"
            };

            for (int i = 0; i < 2; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            Button btnValidades = new Button
            {
                Text = "Validades dos Medicamentos",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnValidades"
            };

            DataGridView dgvRelatorios = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvRelatorios"
            };

            // // Evento do botão para carregar os dados
            // btnValidades.Click += (sender, e) =>
            // {
            //     using (var con = new Conexao())
            //     {
            //         dgvRelatorios.DataSource = con.Vendas.OrderBy(m => m.data_validade).ToList();
            //     }
            // };

            buttonsTable.Controls.Add(btnValidades, 0, 0);
            panel.Controls.Add(buttonsTable, 1, 4);
            panel.Controls.Add(dgvRelatorios, 1, 5);

            return panel;
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new GerenteForm());
        }
    }
}