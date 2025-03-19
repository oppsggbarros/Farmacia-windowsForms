using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Farmacia.Back_End.CRUD;

// using System.IDisposable.
using Farmacia.Back_End.Services;
// #606060 #EBEBEB #233ED9
namespace Front_End
{


    public partial class FarmaceuticoForm : Form
    {
        private TextBox txtCliente, txtMedicamento, txtQuantidade, txtValorTotal, txtCodigoMedicamento;
        private DateTimePicker dtpDataVenda;
        private Button btnInserir, btnExcluir, btnPesquisar, btnValidades;
        private DataGridView dgvConsulta, dgvRelatorios;
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

            btnInserir.Click += new EventHandler(BotaoInserirVenda_click);

            btnExcluir = new Button { Text = "Limpar Venda", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnLimpar" };

            btnExcluir.Click += new EventHandler(BotaoLimparVenda_click);


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
                    int id = Convert.ToInt32(txtMedicamento.Text);
                    // Simula a busca do ID do medicamento com base no nome (ajuste conforme necessário)
                    var medicamento = service.BuscarMedicamentoPorNome(id);
                    if (medicamento != null)
                    {
                        double valorTotal = medicamento.preco * quantidade;
                        txtValorTotal.Text = valorTotal.ToString(); // Formato de moeda
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
        #region PAINEL CONUSLTA
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

            txtCodigoMedicamento = new TextBox { Dock = DockStyle.Fill, Name = "txtCodigoMedicamento" };
            panel.Controls.Add(txtCodigoMedicamento, 0, 2);

            btnPesquisar = new Button { Text = "Pesquisar", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnPesquisar" };

            btnPesquisar.Click += new EventHandler(BotaoListarMEDICAMENTO_click);
            buttonsTable.Controls.Add(btnPesquisar, 0, 3);

            panel.Controls.Add(buttonsTable, 0, 4);

            dgvConsulta = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvConsulta" };
            panel.Controls.Add(dgvConsulta, 0, 5);

            return panel;
        }
        #endregion

        #region PAINEL RELATÓRIOS VALIDADE
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

            btnValidades = new Button
            {
                Text = "Validades dos Medicamentos",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnValidades"
            };

            btnValidades.Click += new EventHandler(BotaoListarValidade_click);

            dgvRelatorios = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvRelatorios"
            };



            buttonsTable.Controls.Add(btnValidades, 0, 0);
            panel.Controls.Add(buttonsTable, 1, 4);
            panel.Controls.Add(dgvRelatorios, 1, 5);

            return panel;
        }

        private void BotaoListarValidade_click(object sender, EventArgs e)
        {
            CRUD_Medicamentos crud = new CRUD_Medicamentos();  // Suponho que o nome da classe seja CRUD_Medicamentos

            try
            {
                dgvRelatorios.DataSource = null;  // Limpa o DataGridView

                // Obtém a lista de medicamentos com a validade ordenada
                var med = crud.Listar_MedicamentosValidade();

                // Verifica se a lista de medicamentos não é nula e contém elementos
                if (med != null && med.Count > 0)
                {
                    dgvRelatorios.DataSource = med;  // Atribui a lista de medicamentos ao DataGridView
                }
                else
                {
                    MessageBox.Show("Nenhum medicamento encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar medicamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

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

        private void BotaoInserirVenda_click(object sender, EventArgs e)
        {
            CRUD_Vendas crud = new();
            try
            {
                string nome = txtCliente.Text;
                int medicamentoId = Convert.ToInt32(txtMedicamento.Text);
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                decimal valor_total = Convert.ToDecimal(txtValorTotal.Text);
                // float valor_total = ffloat.TryParse(txtValorTotal.Text, out valor_total);
                DateTime data_venda = Convert.ToDateTime(dtpDataVenda.Text);

                DialogResult confirmacao = MessageBox.Show("Concluir venda?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    crud.Inserir_Venda(nome, medicamentoId, quantidade, data_venda, valor_total);
                    BotaoLimparVenda_click(sender, e);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao inserir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoLimparVenda_click(object sender, EventArgs e)
        {
            try
            {
                txtCliente.Clear();
                txtMedicamento.Clear();
                txtQuantidade.Clear();
                txtValorTotal.Clear();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao limpar venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoListarMEDICAMENTO_click(object sender, EventArgs e)
        {
            CRUD_Medicamentos crud = new CRUD_Medicamentos();

            try
            {
                int id = Convert.ToInt32(txtCodigoMedicamento.Text);

                dgvRelatorios.DataSource = null;  // Limpa o DataGridView

                var vendas = crud.Consultar_Medicamento(id);  // Obtém as vendas do medicamento
                if (vendas != null && vendas.Count > 0)
                {
                    dgvRelatorios.DataSource = vendas;  // Atribui a lista de vendas ao DataGridView
                }
                else
                {
                    MessageBox.Show("Nenhuma venda encontrada para este medicamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar vendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
