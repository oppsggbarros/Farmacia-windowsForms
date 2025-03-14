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
            TableLayoutPanel panelFornecedores = CriarPainelFornecedores();
            tabFornecedores.Controls.Add(panelFornecedores);

            // Tab 3 - Relatórios
            TabPage tabRelatorios = new TabPage("Controle De Validade");
            TableLayoutPanel panelRelatorios = CriarPainelRelatorios();
            tabRelatorios.Controls.Add(panelRelatorios);

            // tabControl.TabPages.Add(tabUsuarios);
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

        private TableLayoutPanel CriarPainelFornecedores()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true, Name = "panelFornecedores" };

            // Controles de entrada
            Label lblNome = new Label { Text = "Nome:", Name = "lblNomeFornecedor" };
            panel.Controls.Add(lblNome, 0, 0);

            TextBox txtNome = new TextBox { Dock = DockStyle.Fill, Name = "txtNomeFornecedor" };
            panel.Controls.Add(txtNome, 1, 0);

            Label lblCnpj = new Label { Text = "CNPJ:", Name = "lblCnpj" };
            panel.Controls.Add(lblCnpj, 0, 1);

            MaskedTextBox mskCnpj = new MaskedTextBox { Mask = "00.000.000/0000-00", Dock = DockStyle.Fill, Name = "mskCnpj" };
            panel.Controls.Add(mskCnpj, 1, 1);

            Label lblTelefone = new Label { Text = "Telefone:", Name = "lblTelefone" };
            panel.Controls.Add(lblTelefone, 0, 2);

            MaskedTextBox mskTelefone = new MaskedTextBox { Mask = "(00) 00000-0000", Dock = DockStyle.Fill, Name = "mskTelefone" };
            panel.Controls.Add(mskTelefone, 1, 2);

            Label lblEndereco = new Label { Text = "Endereço:", Name = "lblEndereco" };
            panel.Controls.Add(lblEndereco, 0, 3);

            TextBox txtEndereco = new TextBox { Dock = DockStyle.Fill, Name = "txtEndereco" };
            panel.Controls.Add(txtEndereco, 1, 3);

            // Tabela de Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableFornecedores"
            };

            // Adiciona colunas com preenchimento proporcional
            for (int i = 0; i < 4; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            Button btnInserirFornecedor = new Button { Text = "Inserir Fornecedor", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnInserirFornecedor" };
            buttonsTable.Controls.Add(btnInserirFornecedor, 0, 0);

            Button btnListaFornecedor = new Button { Text = "Lista Fornecedor", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnListaFornecedor" };
            buttonsTable.Controls.Add(btnListaFornecedor, 1, 0);

            Button btnAtualizarFornecedor = new Button { Text = "Atualizar Fornecedor", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnAtualizarFornecedor" };
            buttonsTable.Controls.Add(btnAtualizarFornecedor, 2, 0);

            Button btnApagarFornecedor = new Button { Text = "Apagar Fornecedor", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnApagarFornecedor" };
            buttonsTable.Controls.Add(btnApagarFornecedor, 3, 0);

            panel.Controls.Add(buttonsTable, 1, 4);

            DataGridView dgvFornecedores = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvFornecedores" };
            panel.Controls.Add(dgvFornecedores, 1, 5);

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


        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.Run(new GerenteForm());
        // }
    }
}