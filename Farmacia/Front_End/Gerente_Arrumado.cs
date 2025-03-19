using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Farmacia.Back_End.CRUD;
using Farmacia.Back_End.Models;
// #606060 #EBEBEB #233ED9
namespace Front_End
{
    public partial class GerenteForm : Form
    {
        // private CRUD_Fornecedores crud;
        private TextBox txtNomeUsuario, txtNomeFornecedor, txtEndereco;
        private ComboBox cmbCargo;
        private MaskedTextBox mtxtCPF, mtxtCNPJ, mtxtTelefone;
        private TextBox txtSenha;
        private Button btnInserir, btnInserirFornecedor, btnListaFornecedor, btnAtualizarFornecedor, btnApagarFornecedor, btnRelatorioFinanceiro, btnRelatorioEstoque, btnLista, btnAtualizar, btnApagar;
        private DataGridView dgvUsuarios, dgvFornecedores, dgvRelatorios;
        private Label labelNome, labelCNPJ, labelTelefone, labelEndereco;

        public GerenteForm()
        {
            // InitializeComponent();
            ConfigurarInterface();
        }

        private void ConfigurarInterface()
        {
            this.Text = "Painel do Gerente";
            this.Size = new System.Drawing.Size(1000, 600);
            // this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AutoSize = true;

            TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };

            // Tab 1 - Gerenciamento de Usuários
            TabPage tabUsuarios = new TabPage("Gerenciar Usuários");
            TableLayoutPanel panelUsuarios = CriarPainelUsuarios();
            tabUsuarios.Controls.Add(panelUsuarios);

            // Tab 2 - Cadastro de Fornecedores
            TabPage tabFornecedores = new TabPage("Fornecedores");
            TableLayoutPanel panelFornecedores = CriarPainelFornecedores();
            tabFornecedores.Controls.Add(panelFornecedores);

            // Tab 3 - Relatórios
            TabPage tabRelatorios = new TabPage("Relatórios");
            TableLayoutPanel panelRelatorios = CriarPainelRelatorios();
            tabRelatorios.Controls.Add(panelRelatorios);

            tabControl.TabPages.Add(tabUsuarios);
            tabControl.TabPages.Add(tabFornecedores);
            tabControl.TabPages.Add(tabRelatorios);
            this.Controls.Add(tabControl);
        }

        #region  PAINEL USUÁRIOS
        private TableLayoutPanel CriarPainelUsuarios()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
            panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

            // Label e TextBox para Nome
            Label labelNome = new Label { Text = "Nome:", Name = "labelNome" };
            panel.Controls.Add(labelNome, 0, 0);
            txtNomeUsuario = new TextBox { Dock = DockStyle.Fill, Name = "txtNome" };
            panel.Controls.Add(txtNomeUsuario, 1, 0);

            // Label e ComboBox para Cargo
            Label labelCargo = new Label { Text = "Cargo:", Name = "labelCargo" };
            panel.Controls.Add(labelCargo, 0, 1);
            cmbCargo = new ComboBox
            {
                Dock = DockStyle.Fill,
                Name = "cmbCargo",
                Items = { "Gerente", "Farmacêutico", "Atendente" }
            };
            panel.Controls.Add(cmbCargo, 1, 1);

            // Label e MaskedTextBox para CPF
            Label labelCPF = new Label { Text = "CPF:", Name = "labelCPF" };
            panel.Controls.Add(labelCPF, 0, 2);
            mtxtCPF = new MaskedTextBox { Mask = "000.000.000-00", Dock = DockStyle.Fill, Name = "mtxtCPF" };
            panel.Controls.Add(mtxtCPF, 1, 2);

            // Label e TextBox para Senha
            Label labelSenha = new Label { Text = "Senha:", Name = "labelSenha" };
            panel.Controls.Add(labelSenha, 0, 3);
            txtSenha = new TextBox { PasswordChar = '*', Dock = DockStyle.Fill, Name = "txtSenha" };
            panel.Controls.Add(txtSenha, 1, 3);

            // Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTable"
            };

            // Adiciona colunas com preenchimento proporcional
            for (int i = 0; i < 4; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            btnInserir = new Button
            {
                Text = "Inserir Usuário",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnInserir"
            };
            btnInserir.Click += new EventHandler(BotaoInserirUsuario_click);

            buttonsTable.Controls.Add(btnInserir, 0, 0);

            btnLista = new Button
            {
                Text = "Lista Usuário",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnLista"
            };
            btnLista.Click += new EventHandler(BotaoListarUsuarios_click);

            buttonsTable.Controls.Add(btnLista, 1, 0);

            btnAtualizar = new Button
            {
                Text = "Atualizar Usuário",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnAtualizar"
            };
            btnAtualizar.Click += new EventHandler(BotaoAtualizarUsuario_click);

            buttonsTable.Controls.Add(btnAtualizar, 2, 0);

            btnApagar = new Button
            {
                Text = "Apagar Usuário",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnApagar"
            };
            btnApagar.Click += new EventHandler(BotaoDeletarUsuario_click);

            buttonsTable.Controls.Add(btnApagar, 3, 0);

            panel.Controls.Add(buttonsTable, 1, 4);

            // DataGridView
            dgvUsuarios = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvUsuarios"
            };
            panel.Controls.Add(dgvUsuarios, 1, 5);

            return panel;
        }
        #endregion

        #region PAINEL FORNECEDORES

        private TableLayoutPanel CriarPainelFornecedores()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };
            panel.BackColor = ColorTranslator.FromHtml("#EBEBEB");

            // Label e TextBox para Nome
            labelNome = new Label { Text = "Nome:", Name = "labelNomeFornecedor" };
            panel.Controls.Add(labelNome, 0, 0);
            txtNomeFornecedor = new TextBox { Dock = DockStyle.Fill, Name = "txtNomeFornecedor" };
            panel.Controls.Add(txtNomeFornecedor, 1, 0);

            // Label e MaskedTextBox para CNPJ
            labelCNPJ = new Label { Text = "CNPJ:", Name = "labelCNPJ" };
            panel.Controls.Add(labelCNPJ, 0, 1);
            mtxtCNPJ = new MaskedTextBox { Mask = "00.000.000/0000-00", Dock = DockStyle.Fill, Name = "mtxtCNPJ" };
            // mtxtCNPJ = new MaskedTextBox { Dock = DockStyle.Fill, Name = "mtxtCNPJ" };
            panel.Controls.Add(mtxtCNPJ, 1, 1);

            // Label e MaskedTextBox para Telefone
            labelTelefone = new Label { Text = "Telefone:", Name = "labelTelefone" };
            panel.Controls.Add(labelTelefone, 0, 2);
            // mtxtTelefone = new MaskedTextBox { Dock = DockStyle.Fill, Name = "mtxtTelefone" };
            mtxtTelefone = new MaskedTextBox { Mask = "(00) 00000-0000", Dock = DockStyle.Fill, Name = "mtxtTelefone" };
            panel.Controls.Add(mtxtTelefone, 1, 2);

            // Label e TextBox para Endereço
            labelEndereco = new Label { Text = "Endereço:", Name = "labelEndereco" };
            panel.Controls.Add(labelEndereco, 0, 3);
            txtEndereco = new TextBox { Dock = DockStyle.Fill, Name = "txtEndereco" };
            panel.Controls.Add(txtEndereco, 1, 3);

            // Botões
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

            btnInserir = new Button
            {
                Text = "Inserir Fornecedor",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnInserirFornecedor"
            };

            btnInserir.Click += new EventHandler(BotaoInserirFornecedor_click);

            buttonsTable.Controls.Add(btnInserir, 0, 0);

            Button btnLista = new Button
            {
                Text = "Lista Fornecedor",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnListaFornecedor"
            };
            btnLista.Click += new EventHandler(BotaoListarFornecedores_click);
            buttonsTable.Controls.Add(btnLista, 1, 0);


            btnAtualizar = new Button
            {
                Text = "Atualizar Fornecedor",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnAtualizarFornecedor"
            };
            
            btnAtualizar.Click += new EventHandler(BotaoAtualizarFornecedor_click);
            
            buttonsTable.Controls.Add(btnAtualizar, 2, 0);

            btnApagar = new Button
            {
                Text = "Apagar Fornecedor",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnApagarFornecedor"
            };
            buttonsTable.Controls.Add(btnApagar, 3, 0);
            btnApagar.Click += new EventHandler(BotaoDeletarFornecedor_click);

            panel.Controls.Add(buttonsTable, 1, 4);

            // DataGridView
            dgvFornecedores = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvFornecedores"
            };
            panel.Controls.Add(dgvFornecedores, 1, 5);

            return panel;
        }

        #endregion

        private TableLayoutPanel CriarPainelRelatorios()
        {
            TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoSize = true };

            // Botões
            TableLayoutPanel buttonsTable = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Name = "buttonsTableRelatorios"
            };

            // Adiciona colunas com preenchimento proporcional
            for (int i = 0; i < 2; i++)
                buttonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Botão Relatório Financeiro
            Button btnRelatorioFinanceiro = new Button
            {
                Text = "Relatório Financeiro",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnRelatorioFinanceiro"
            };
            buttonsTable.Controls.Add(btnRelatorioFinanceiro, 0, 0);

            // Botão Relatório de Estoque
            Button btnRelatorioEstoque = new Button
            {
                Text = "Relatório de Estoque",
                BackColor = ColorTranslator.FromHtml("#233ED9"),
                ForeColor = ColorTranslator.FromHtml("#FFF"),
                Height = 50,
                Dock = DockStyle.Fill,
                Name = "btnRelatorioEstoque"
            };
            buttonsTable.Controls.Add(btnRelatorioEstoque, 1, 0);

            // Adiciona a tabela de botões ao painel
            panel.Controls.Add(buttonsTable, 1, 4);

            // DataGridView para exibição de relatórios
            dgvRelatorios = new DataGridView
            {
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.Black,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                Name = "dgvRelatorios"
            };
            panel.Controls.Add(dgvRelatorios, 1, 5);

            return panel;
        }

        #region Botões Eventos Fornecedores
        private void BotaoInserirFornecedor_click(object sender, EventArgs e)
        {
            CRUD_Fornecedores crud = new();

            // POR FAVOR WILL DO FUTURO, TIRAR OS CARACTERES DO CNPJ, CPF E TELEFONE PARA ARRUMAR ESTE ERRO
            // ASS: WILL DO PASSADO

            try
            {
                string nome = txtNomeFornecedor.Text; // Use txtNomeFornecedor em vez de txtNome
                string cnpj = mtxtCNPJ.Text;
                string cnpjConvertido = Regex.Replace(cnpj, "[^0-9]", "");
                string telefone = mtxtTelefone.Text;
                string telefoneConvertido = Regex.Replace(telefone, "[^0-9]", "");
                string endereco = txtEndereco.Text;

                MessageBox.Show($"nome: {nome}, cnpj: {cnpjConvertido}, telefone: {telefoneConvertido}, endereco: {endereco}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                crud.Inserir_Fornecedor(nome, cnpjConvertido, telefoneConvertido, endereco);

                txtNomeFornecedor.Clear();
                mtxtCNPJ.Clear();
                mtxtTelefone.Clear();
                txtEndereco.Clear();
                BotaoListarFornecedores_click(sender, e);

                MessageBox.Show("Fornecedor inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao inserir fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoListarFornecedores_click(object sender, EventArgs e)
        {
            CRUD_Fornecedores crud = new CRUD_Fornecedores();

            try
            {
                List<Fornecedores> fornecedores = crud.Listar_Fornecedores();
                if (fornecedores.Count > 0)
                {
                    dgvFornecedores.DataSource = null;
                    dgvFornecedores.DataSource = fornecedores;
                }
                else
                {
                    MessageBox.Show($"Não há fornecedores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao listar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoAtualizarFornecedor_click(object sender, EventArgs e)
        {
            CRUD_Fornecedores crud = new();
            try
            {
                string nome = txtNomeFornecedor.Text; 
                string cnpj = mtxtCNPJ.Text;
                string cnpjConvertido = Regex.Replace(cnpj, "[^0-9]", "");
                string telefone = mtxtTelefone.Text;
                string telefoneConvertido = Regex.Replace(telefone, "[^0-9]", "");
                string endereco = txtEndereco.Text;

                DialogResult confirmacao = MessageBox.Show($"nome: {nome}, cnpj: {cnpjConvertido}, telefone: {telefoneConvertido}, endereco: {endereco}\n Gostaria de continuar com a atualização?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    crud.Atualizar_Fornecedor(nome, cnpjConvertido, telefoneConvertido, endereco);
                    BotaoListarFornecedores_click(sender, e);
                }



            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao Atualizar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BotaoDeletarFornecedor_click(object sender, EventArgs e)
        {
            CRUD_Fornecedores crud = new();
            try
            {
                if (dgvFornecedores.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvFornecedores.SelectedRows[0].Cells["id"].Value);

                    DialogResult confirmacao = MessageBox.Show("Tem certeza que deseja excluir este fornecedor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacao == DialogResult.Yes)
                    {
                        crud.Excluir_Fornecedor(id);
                        BotaoListarFornecedores_click(sender, e);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao Deletar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Botões Eventos Usuarios

        private void BotaoInserirUsuario_click(object sender, EventArgs e)
        {
            CRUD_Usuarios crud = new ();

            // POR FAVOR WILL DO FUTURO, TIRAR OS CARACTERES DO CNPJ, CPF E TELEFONE PARA ARRUMAR ESTE ERRO
            // ASS: WILL DO PASSADO

            try
            {
                string nome = txtNomeUsuario.Text; 
                string cpf = mtxtCPF.Text;
                string cpfConvertido = Regex.Replace(cpf, "[^0-9]", "");
                string cargo = cmbCargo.Text;
                string senha = txtSenha.Text;

                MessageBox.Show($"nome: {nome}, cpf: {cpfConvertido}, cargo: {cargo}, endereco: {senha}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                crud.Inserir_Usuario(nome, cargo, cpfConvertido, senha);

                txtNomeUsuario.Clear();
                mtxtCPF.Clear();
                txtSenha.Clear();
                BotaoListarUsuarios_click(sender, e);

                MessageBox.Show("Usuário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao inserir Usuario: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoListarUsuarios_click(object sender, EventArgs e)
        {
            CRUD_Usuarios crud = new CRUD_Usuarios();

            try
            {
                List<Usuarios> usuarios = crud.Listar_Usuarios();
                if (usuarios.Count > 0)
                {
                    dgvUsuarios.DataSource = null;
                    dgvUsuarios.DataSource = usuarios;
                }
                else
                {
                    MessageBox.Show($"Não há usuários", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao listar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoAtualizarUsuario_click(object sender, EventArgs e)
        {
            CRUD_Usuarios crud = new();
            try
            {
                string nome = txtNomeFornecedor.Text; 
                string cpf = mtxtCPF.Text;
                string cpfConvertido = Regex.Replace(cpf, "[^0-9]", "");
                string cargo = cmbCargo.Text;
                string senha = txtSenha.Text;

                DialogResult confirmacao = MessageBox.Show($"nome: {nome}, cpf: {cpfConvertido}, cargo: {cargo}, senha: {senha}\n Gostaria de continuar com a atualização?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    crud.Atualizar_Usuario(nome, cargo, cpfConvertido, senha);
                    BotaoListarFornecedores_click(sender, e);
                }



            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao Atualizar Usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BotaoDeletarUsuario_click(object sender, EventArgs e)
        {
            CRUD_Usuarios crud = new();
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);

                    DialogResult confirmacao = MessageBox.Show("Tem certeza que deseja excluir este usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacao == DialogResult.Yes)
                    {
                        crud.Excluir_Usuario(id);
                        BotaoListarUsuarios_click(sender, e);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao Deletar Usuarios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        // MExi em Gerentye arrumado e os crud's do fornecedor(Funcionando Corretamente) e usuários(Não funcionando)
        //     [STAThread]
        //     static void Main()
        //     {
        //         Application.EnableVisualStyles();
        //         Application.Run(new GerenteForm());
        //     }

    }
}
