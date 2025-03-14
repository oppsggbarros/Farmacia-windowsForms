// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// // #606060 #EBEBEB #233ED9
// namespace Front_End
// {
//     public partial class GerenteForm : Form
//     {
//         public GerenteForm()
//         {
//             // InitializeComponent();
//             ConfigurarInterface();
//         }

//         private void ConfigurarInterface()
//         {
//             this.Text = "Painel do Gerente";
//             this.Size = new System.Drawing.Size(1000, 600);
//             // this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
//             this.AutoSize = true;

//             TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };

//             // Tab 1 - Gerenciamento de Usuários
//             TabPage tabUsuarios = new TabPage("Gerenciar Usuários");
//             TableLayoutPanel panelUsuarios = CriarPainelUsuarios();
//             tabUsuarios.Controls.Add(panelUsuarios);

//             // Tab 2 - Cadastro de Fornecedores
//             TabPage tabFornecedores = new TabPage("Fornecedores");
//             TableLayoutPanel panelFornecedores = CriarPainelFornecedores();
//             tabFornecedores.Controls.Add(panelFornecedores);

//             // Tab 3 - Relatórios
//             TabPage tabRelatorios = new TabPage("Relatórios");
//             TableLayoutPanel panelRelatorios = CriarPainelRelatorios();
//             tabRelatorios.Controls.Add(panelRelatorios);

//             tabControl.TabPages.Add(tabUsuarios);
//             tabControl.TabPages.Add(tabFornecedores);
//             tabControl.TabPages.Add(tabRelatorios);
//             this.Controls.Add(tabControl);
//         }

//         private TableLayoutPanel CriarPainelUsuarios()
//         {
//             TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
//             panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

//             // Label e TextBox para Nome
//             Label labelNome = new Label { Text = "Nome:", Name = "labelNome" };
//             panel.Controls.Add(labelNome, 0, 0);
//             TextBox txtNome = new TextBox { Dock = DockStyle.Fill, Name = "txtNome" };
//             panel.Controls.Add(txtNome, 1, 0);

//             // Label e ComboBox para Cargo
//             Label labelCargo = new Label { Text = "Cargo:", Name = "labelCargo" };
//             panel.Controls.Add(labelCargo, 0, 1);
//             ComboBox cmbCargo = new ComboBox
//             {
//                 Dock = DockStyle.Fill,
//                 Name = "cmbCargo",
//                 Items = { "Gerente", "Farmacêutico", "Atendente" }
//             };
//             panel.Controls.Add(cmbCargo, 1, 1);

//             // Label e MaskedTextBox para CPF
//             Label labelCPF = new Label { Text = "CPF:", Name = "labelCPF" };
//             panel.Controls.Add(labelCPF, 0, 2);
//             MaskedTextBox mtxtCPF = new MaskedTextBox { Mask = "000.000.000-00", Dock = DockStyle.Fill, Name = "mtxtCPF" };
//             panel.Controls.Add(mtxtCPF, 1, 2);

//             // Label e TextBox para Senha
//             Label labelSenha = new Label { Text = "Senha:", Name = "labelSenha" };
//             panel.Controls.Add(labelSenha, 0, 3);
//             TextBox txtSenha = new TextBox { PasswordChar = '*', Dock = DockStyle.Fill, Name = "txtSenha" };
//             panel.Controls.Add(txtSenha, 1, 3);

//             // Botões
//             TableLayoutPanel buttonsTable = new TableLayoutPanel
//             {
//                 ColumnCount = 4,
//                 Dock = DockStyle.Fill,
//                 AutoSize = true,
//                 Name = "buttonsTable"
//             };

//             // Adiciona colunas com preenchimento proporcional
//             for (int i = 0; i < 4; i++)
//                 buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

//             Button btnInserir = new Button
//             {
//                 Text = "Inserir Usuário",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnInserir"
//             };
//             buttonsTable.Controls.Add(btnInserir, 0, 0);

//             Button btnLista = new Button
//             {
//                 Text = "Lista Usuário",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnLista"
//             };
//             buttonsTable.Controls.Add(btnLista, 1, 0);

//             Button btnAtualizar = new Button
//             {
//                 Text = "Atualizar Usuário",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnAtualizar"
//             };
//             buttonsTable.Controls.Add(btnAtualizar, 2, 0);

//             Button btnApagar = new Button
//             {
//                 Text = "Apagar Usuário",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnApagar"
//             };
//             buttonsTable.Controls.Add(btnApagar, 3, 0);

//             panel.Controls.Add(buttonsTable, 1, 4);

//             // DataGridView
//             DataGridView dgvUsuarios = new DataGridView
//             {
//                 BorderStyle = BorderStyle.FixedSingle,
//                 ForeColor = Color.Black,
//                 BackgroundColor = Color.White,
//                 Dock = DockStyle.Fill,
//                 Name = "dgvUsuarios"
//             };
//             panel.Controls.Add(dgvUsuarios, 1, 5);

//             return panel;
//         }

//         private TableLayoutPanel CriarPainelFornecedores()
//         {
//             TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
//             panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

//             // Label e TextBox para Nome
//             Label labelNome = new Label { Text = "Nome:", Name = "labelNomeFornecedor" };
//             panel.Controls.Add(labelNome, 0, 0);
//             TextBox txtNome = new TextBox { Dock = DockStyle.Fill, Name = "txtNomeFornecedor" };
//             panel.Controls.Add(txtNome, 1, 0);

//             // Label e MaskedTextBox para CNPJ
//             Label labelCNPJ = new Label { Text = "CNPJ:", Name = "labelCNPJ" };
//             panel.Controls.Add(labelCNPJ, 0, 1);
//             MaskedTextBox mtxtCNPJ = new MaskedTextBox { Mask = "00.000.000/0000-00", Dock = DockStyle.Fill, Name = "mtxtCNPJ" };
//             panel.Controls.Add(mtxtCNPJ, 1, 1);

//             // Label e MaskedTextBox para Telefone
//             Label labelTelefone = new Label { Text = "Telefone:", Name = "labelTelefone" };
//             panel.Controls.Add(labelTelefone, 0, 2);
//             MaskedTextBox mtxtTelefone = new MaskedTextBox { Mask = "(00) 00000-0000", Dock = DockStyle.Fill, Name = "mtxtTelefone" };
//             panel.Controls.Add(mtxtTelefone, 1, 2);

//             // Label e TextBox para Endereço
//             Label labelEndereco = new Label { Text = "Endereço:", Name = "labelEndereco" };
//             panel.Controls.Add(labelEndereco, 0, 3);
//             TextBox txtEndereco = new TextBox { Dock = DockStyle.Fill, Name = "txtEndereco" };
//             panel.Controls.Add(txtEndereco, 1, 3);

//             // Botões
//             TableLayoutPanel buttonsTable = new TableLayoutPanel
//             {
//                 ColumnCount = 4,
//                 Dock = DockStyle.Fill,
//                 AutoSize = true,
//                 Name = "buttonsTableFornecedores"
//             };

//             // Adiciona colunas com preenchimento proporcional
//             for (int i = 0; i < 4; i++)
//                 buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

//             Button btnInserir = new Button
//             {
//                 Text = "Inserir Fornecedor",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnInserirFornecedor"
//             };
//             buttonsTable.Controls.Add(btnInserir, 0, 0);

//             Button btnLista = new Button
//             {
//                 Text = "Lista Fornecedor",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnListaFornecedor"
//             };
//             buttonsTable.Controls.Add(btnLista, 1, 0);

//             Button btnAtualizar = new Button
//             {
//                 Text = "Atualizar Fornecedor",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnAtualizarFornecedor"
//             };
//             buttonsTable.Controls.Add(btnAtualizar, 2, 0);

//             Button btnApagar = new Button
//             {
//                 Text = "Apagar Fornecedor",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnApagarFornecedor"
//             };
//             buttonsTable.Controls.Add(btnApagar, 3, 0);

//             panel.Controls.Add(buttonsTable, 1, 4);

//             // DataGridView
//             DataGridView dgvFornecedores = new DataGridView
//             {
//                 BorderStyle = BorderStyle.FixedSingle,
//                 ForeColor = Color.Black,
//                 BackgroundColor = Color.White,
//                 Dock = DockStyle.Fill,
//                 Name = "dgvFornecedores"
//             };
//             panel.Controls.Add(dgvFornecedores, 1, 5);

//             return panel;
//         }


//         private TableLayoutPanel CriarPainelRelatorios()
//         {
//             TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };

//             // Botões
//             TableLayoutPanel buttonsTable = new TableLayoutPanel
//             {
//                 ColumnCount = 2,
//                 Dock = DockStyle.Fill,
//                 AutoSize = true,
//                 Name = "buttonsTableRelatorios"
//             };

//             // Adiciona colunas com preenchimento proporcional
//             for (int i = 0; i < 2; i++)
//                 buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

//             // Botão Relatório Financeiro
//             Button btnRelatorioFinanceiro = new Button
//             {
//                 Text = "Relatório Financeiro",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnRelatorioFinanceiro"
//             };
//             buttonsTable.Controls.Add(btnRelatorioFinanceiro, 0, 0);

//             // Botão Relatório de Estoque
//             Button btnRelatorioEstoque = new Button
//             {
//                 Text = "Relatório de Estoque",
//                 BackColor = ColorTranslator.FromHtml("#233ED9"),
//                 ForeColor = ColorTranslator.FromHtml("#FFF"),
//                 Height = 50,
//                 Dock = DockStyle.Fill,
//                 Name = "btnRelatorioEstoque"
//             };
//             buttonsTable.Controls.Add(btnRelatorioEstoque, 1, 0);

//             // Adiciona a tabela de botões ao painel
//             panel.Controls.Add(buttonsTable, 1, 4);

//             // DataGridView para exibição de relatórios
//             DataGridView dgvRelatorios = new DataGridView
//             {
//                 BorderStyle = BorderStyle.FixedSingle,
//                 ForeColor = Color.Black,
//                 BackgroundColor = Color.White,
//                 Dock = DockStyle.Fill,
//                 Name = "dgvRelatorios"
//             };
//             panel.Controls.Add(dgvRelatorios, 1, 5);

//             return panel;
//         }


//         [STAThread]
//         static void Main()
//         {
//             Application.EnableVisualStyles();
//             Application.Run(new GerenteForm());
//         }
//     }
// }
