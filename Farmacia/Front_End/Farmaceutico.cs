// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Front_End
// {
//     public partial class FarmaceuticoForm : Form
//     {
//         public FarmaceuticoForm()
//         {
//             // InitializeComponent();
//             ConfigurarInterface();
//         }

//         private void ConfigurarInterface()
//         {
//             this.Text = "Painel do Farmacêutico";
//             this.Size = new System.Drawing.Size(800, 600);
//             this.AutoSize = true;

//             TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };
//             TabPage tabPesquisa = new TabPage("Consulta de Medicamentos");
//             TabPage tabVendas = new TabPage("Registro de Vendas");
//             TabPage tabValidade = new TabPage("Controle de Validade");

//             tabControl.TabPages.Add(tabPesquisa);
//             tabControl.TabPages.Add(tabVendas);
//             tabControl.TabPages.Add(tabValidade);
//             this.Controls.Add(tabControl);
//         }

//         [STAThread]
//         static void Main()
//         {
//             Application.EnableVisualStyles();
//             Application.Run(new FarmaceuticoForm());
//         }
//     }
// }