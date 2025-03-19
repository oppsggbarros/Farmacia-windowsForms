using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Farmacia.Back_End.ConexaoBanco;
using Farmacia.Back_End.CRUD;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.Services;

namespace Front_End
{
    public partial class AtendenteForm : Form
    {
        private TextBox txtCliente, txtMedicamento, txtQuantidade, txtValorTotal, txtCodigoMedicamento;
        private Button btnInserir, btnLista, btnPesquisar;
        private DataGridView dgvVendas, dgvConsulta;
        public AtendenteForm()
        {
            // InitializeComponent();
            ConfigurarInterface();
        }

        #region Configuração da Interface
        private void ConfigurarInterface()
        {
            this.Text = "Painel do Atendente";
            this.Size = new System.Drawing.Size(1000, 600);
            this.AutoSize = true;

            TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };

            // Tab 1 - Registro de Venda
            TabPage tabRegistro = new TabPage("Registro de Venda");
            TableLayoutPanel panelRegistro = CriarPainelRegistro();
            tabRegistro.Controls.Add(panelRegistro);

            // Tab 2 - Consulta Produtos
            TabPage tabConsulta = new TabPage("Consulta Produtos");
            TableLayoutPanel panelConsulta = CriarPainelConsulta();
            tabConsulta.Controls.Add(panelConsulta);

            tabControl.TabPages.Add(tabRegistro);
            tabControl.TabPages.Add(tabConsulta);
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
        #endregion

        #region Painel de Registro
        private TableLayoutPanel CriarPainelRegistro()
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

            DateTimePicker dtpDataVenda = new DateTimePicker { Dock = DockStyle.Fill, Enabled = false, Name = "dtpDataVenda" };
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

            btnInserir = new Button { Text = "Inserir Medicamento", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnInserir" };
            btnInserir.Click += new EventHandler(btnInserir_Click);
            buttonsTable.Controls.Add(btnInserir, 0, 0);



            btnLista = new Button { Text = "Limpar Campos", BackColor = ColorTranslator.FromHtml("#233ED9"), ForeColor = ColorTranslator.FromHtml("#FFF"), Height = 50, Dock = DockStyle.Fill, Name = "btnLista" };
            btnLista.Click += new EventHandler(btnLimpar_Click);
            buttonsTable.Controls.Add(btnLista, 1, 0);

            dgvVendas = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvVendas"
            };

            panel.Controls.Add(buttonsTable, 1, 6);

            DataGridView dgvRegistro = new DataGridView { BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.Black, BackgroundColor = Color.White, Dock = DockStyle.Fill, Name = "dgvRegistro" };
            panel.Controls.Add(dgvRegistro, 1, 7);


            return panel;
        }

        private void CalcularValorTotal()
        {
            if (int.TryParse(txtQuantidade.Text, out int quantidade) && !string.IsNullOrWhiteSpace(txtMedicamento.Text))
            {
                using (var service = new MedicamentoService())
                {
                    int id = Convert.ToInt32(txtMedicamento.Text);

                    var medicamento = service.BuscarMedicamentoPorNome(id);
                    if (medicamento != null)
                    {
                        double valorTotal = medicamento.preco * quantidade;
                        txtValorTotal.Text = valorTotal.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Medicamento não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtValorTotal.Text = string.Empty;
            }
        }
        #endregion

        #region Painel de Consulta
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
            btnPesquisar.Click += new EventHandler(btnPesquiar_Click);
            buttonsTable.Controls.Add(btnPesquisar, 0, 3);

            panel.Controls.Add(buttonsTable, 0, 4);

            dgvConsulta = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvConsulta"
            };

            panel.Controls.Add(dgvConsulta, 0, 5);
            panel.Controls.Add(dgvConsulta, 0, 5);

            return panel;
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            CRUD_Vendas crudVendas = new CRUD_Vendas();

            txtCliente.Clear();
            txtMedicamento.Clear();
            txtQuantidade.Clear();
            txtValorTotal.Clear();
            // crudVendas.Mostrar_Vendas(); 

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            CRUD_Vendas crudVendas = new CRUD_Vendas();

            try
            {
                string nome = txtCliente.Text;
                int medicamento = Convert.ToInt32(txtMedicamento.Text);
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                DateTime data_venda = DateTime.Now;
                decimal valor_total = Convert.ToDecimal(txtValorTotal.Text);

                crudVendas.Inserir_Venda(nome, medicamento, quantidade, data_venda, valor_total);


                MessageBox.Show($"Venda inserida com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao inserir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquiar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCodigoMedicamento.Text);

            using (var con = new Conexao())
            {
                try
                {
                    var medicamento = con.Medicamentos.Find(id);

                    if (medicamento != null)
                    {
                        dgvConsulta.Rows.Clear();
                        dgvConsulta.Columns.Clear();

                        dgvConsulta.Columns.Add("id", "ID");
                        dgvConsulta.Columns.Add("nome", "Nome");
                        dgvConsulta.Columns.Add("preco", "Preço");
                        dgvConsulta.Columns.Add("quantidade", "Quantidade");

                        dgvConsulta.Rows.Add(medicamento.id, medicamento.nome, medicamento.preco);
                    }
                    else
                    {
                        MessageBox.Show("Medicamento não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Erro ao pesquisar medicamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.Run(new AtendenteForm());
        // }
    }
}