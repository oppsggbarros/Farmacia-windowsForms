// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Front_End
// {
//     public partial class AtendenteForm : Form
//     {
//         public AtendenteForm()
//         {
//             // InitializeComponent();
//             ConfigurarInterface();
//         }

//         private void ConfigurarInterface()
//         {
//             this.Text = "Painel do Atendente";
//             this.Size = new System.Drawing.Size(1000, 600);
//             this.AutoSize = true;

//             TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };

//             // Tab 1 - Registro de Venda
//             TabPage tabRegistro = new TabPage("Registro de Venda");
//             TableLayoutPanel panelRegistro = CriarPainelRegistro();
//             tabRegistro.Controls.Add(panelRegistro);

//             // Tab 2 - Consulta Produtos
//             TabPage tabConsulta = new TabPage("Consulta Produtos");
//             TableLayoutPanel panelConsulta = CriarPainelConsulta();
//             tabConsulta.Controls.Add(panelConsulta);

//             tabControl.TabPages.Add(tabRegistro);
//             tabControl.TabPages.Add(tabConsulta);
//             this.Controls.Add(tabControl);
//         }

//         private TableLayoutPanel CriarPainelRegistro()
//         {
//             TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
//             panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");
//             panel.Controls.Add(new Label { Text = "Cliente:" }, 0, 0);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 0);
//             panel.Controls.Add(new Label { Text = "Nome:" }, 0, 1);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 1);
//             panel.Controls.Add(new Label { Text = "Medicamento:" }, 0, 2);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 2);
//             panel.Controls.Add(new Label { Text = "Quantidade:" }, 0, 3);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 1, 3);
//             panel.Controls.Add(new Label { Text = "Data da Venda:" }, 0, 4);
//             panel.Controls.Add(new DateTimePicker { Dock = DockStyle.Fill, Enabled = false }, 1, 4);
//             panel.Controls.Add(new Label { Text = "Valor Total:" }, 0, 5);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill, Enabled = false }, 1, 5);


//             TableLayoutPanel buttonsTable = new TableLayoutPanel
//             {
//                 ColumnCount = 4,
//                 Dock = DockStyle.Fill,
//                 AutoSize = true
//             };

//             // Adiciona colunas com preenchimento proporcional
//             for (int i = 0; i < 4; i++)
//                 buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

//             buttonsTable.Controls.Add(new Button { Text = "Inserir Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill }, 0, 0);
//             buttonsTable.Controls.Add(new Button { Text = "Lista Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill }, 1, 0);
//             buttonsTable.Controls.Add(new Button { Text = "Atualizar Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill }, 2, 0);
//             buttonsTable.Controls.Add(new Button { Text = "Apagar Usuário", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill }, 3, 0);

//             panel.Controls.Add(buttonsTable, 1, 6);

//             panel.Controls.Add(new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill }, 1, 7);
//             return panel;
//         }

//         private TableLayoutPanel CriarPainelConsulta()
//         {
//             TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true };

//             TableLayoutPanel buttonsTable = new TableLayoutPanel
//             {
//                 ColumnCount = 1,
//                 Dock = DockStyle.Fill,
//                 AutoSize = true
//             };

//             // Adiciona colunas com preenchimento proporcional
//             for (int i = 0; i < 1; i++)
//                 buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

//             panel.Controls.Add(new Label { Text = "Cód do Medicamento:" , Dock = DockStyle.Fill }, 0, 1);
//             panel.Controls.Add(new TextBox { Dock = DockStyle.Fill }, 0, 2);
//             buttonsTable.Controls.Add(new Button { Text = "Pesquisar", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill }, 0, 3);

//             panel.Controls.Add(buttonsTable, 0, 4);

//             panel.Controls.Add(new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill }, 0, 5);

//             return panel;
//         }

//         [STAThread]
//         static void Main()
//         {
//             Application.EnableVisualStyles();
//             Application.Run(new AtendenteForm());
//         }
//     }
// }