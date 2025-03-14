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
//             this.Size = new System.Drawing.Size(800, 600);
//             this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
//             this.AutoSize = true;

//             TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };
//             TabPage tabRegistroVendas = new TabPage("Registro Rápido de Vendas");
//             TabPage tabConsultaPrecos = new TabPage("Consulta de Preços");

//             tabControl.TabPages.Add(tabRegistroVendas);
//             tabControl.TabPages.Add(tabConsultaPrecos);
//             this.Controls.Add(tabControl);
//         }

//         [STAThread]
//         static void Main()
//         {
//             Application.EnableVisualStyles();
//             Application.Run(new AtendenteForm());
//         }
//     }
// }