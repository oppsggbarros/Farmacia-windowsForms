using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmacia.Back_End.CRUD;

// using System.IDisposable.
using Farmacia.Back_End.Services;
// #606060 #EBEBEB #233ED9
namespace Front_End
{
    public partial class FarmaceuticoForm : Form
    {
        private TextBox txtCliente, txtMedicamento, txtQuantidade, txtValorTotal;
        private DateTimePicker dtpDataVenda;
        private Button btnInserir, btnExcluir;
        public FarmaceuticoForm()
        {
            // InitializeComponent();
            ConfigurarInterface();
        }

        private void ConfigurarInterface()
        {
            this.Text = "Painel do Farmaceutico";
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

            // Criando o botão de Logout
            Button btnLogout = new Button
            {
                Text = "Sair",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Dock = DockStyle.Bottom,
                Height = 40
            };

            btnLogout.Click += BtnLogout_Click;

            // Adicionando o botão à interface
            this.Controls.Add(btnLogout);
        }

        #region  PAINEL VENDAS
        private TableLayoutPanel CriarPainelUsuarios()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true, Name = "panelRegistro" };
            panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

            // Controles de entrada
            Label lblCliente = new Label { Text = "Cliente:", Name = "lblCliente" };
            panel.Controls.Add(lblCliente, 0, 0);

            txtCliente = new TextBox { Dock = DockStyle.Fill, Name = "txtCliente" };
            panel.Controls.Add(txtCliente, 1, 0);

            Label lblMedicamento = new Label { Text = "Medicamento:", Name = "lblMedicamento" };
            panel.Controls.Add(lblMedicamento, 0, 2);

            txtMedicamento = new TextBox { Dock = DockStyle.Fill, Name = "txtMedicamento" };
            panel.Controls.Add(txtMedicamento, 1, 2);

            Label lblQuantidade = new Label { Text = "Quantidade:", Name = "lblQuantidade" };
            panel.Controls.Add(lblQuantidade, 0, 3);

            txtQuantidade = new TextBox { Dock = DockStyle.Fill, Name = "txtQuantidade" };
            panel.Controls.Add(txtQuantidade, 1, 3);

            Label lblDataVenda = new Label { Text = "Data da Venda:", Name = "lblDataVenda" };
            panel.Controls.Add(lblDataVenda, 0, 4);

            dtpDataVenda = new DateTimePicker { Dock = DockStyle.Fill, Enabled = false, Name = "dtpDataVenda" };
            panel.Controls.Add(dtpDataVenda, 1, 4);

            Label lblValorTotal = new Label { Text = "Valor Total:", Name = "lblValorTotal" };
            panel.Controls.Add(lblValorTotal, 0, 5);

            txtValorTotal = new TextBox { Dock = DockStyle.Fill, Enabled = false, Name = "txtValorTotal" };
            panel.Controls.Add(txtValorTotal, 1, 5);

            txtQuantidade.TextChanged += (s, e) => CalcularValorTotal();

            // Tabela de Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableRegistro"
            };

            // Adiciona colunas com preenchimento proporcional
            for (int i = 0; i < 2; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            btnInserir = new Button { Text = "Registrar venda", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnInserir" };
            buttonsTable.Controls.Add(btnInserir, 0, 0);

            // btnInserir.Click += new EventHandler(BotaoInserirVenda_click);

            btnExcluir = new Button { Text = "Excluir Venda", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnExcluir" };


            buttonsTable.Controls.Add(btnExcluir, 1, 0);

            panel.Controls.Add(buttonsTable, 1, 6);

            DataGridView dgvRegistro = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvRegistro" };
            panel.Controls.Add(dgvRegistro, 1, 7);

            return panel;
        }

        // CalcularValorTotal
        private void CalcularValorTotal()
        {
            if (int.TryParse(txtQuantidade.Text, out int quantidade) && !string.IsNullOrWhiteSpace(txtMedicamento.Text))
            {
                using (var service = new MedicamentoService())
                {
                    int id = Convert.ToInt32(txtQuantidade.Text);
                    // Simula a busca do ID do medicamento com base no nome (ajuste conforme necessário)
                    var medicamento = service.BuscarMedicamentoPorNome(id);
                    if (medicamento != null)
                    {
                        double valorTotal = medicamento.preco * quantidade;
                        txtValorTotal.Text = valorTotal.ToString("C2"); // Formato de moeda
                    }
                    else
                    {
                        MessageBox.Show("Medicamento não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtValorTotal.Text = string.Empty; // Limpa o campo se não for válido
            }
        }

        #endregion
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

        // Evento de clique do botão de Logout
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Exibe a tela de login novamente
            Login loginForm = new Login();
            loginForm.Show();

            // Esconde a tela do atendente
            this.Hide();
        }

        #region Botões Eventos Vendas

        private void BotaoInserirVenda_click(string cliente_nome, int medicamento_id, int quantidade, DateTime data_venda, float valor_total)
        {
            CRUD_Vendas crud = new();
            try
            {
                // string nome = 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao inserir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    #endregion


    // [STAThread]
    // static void Main()
    // {
    //     Application.EnableVisualStyles();
    //     Application.Run(new FarmaceuticoForm());
    // }
}
