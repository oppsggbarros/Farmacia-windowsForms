// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using System.Windows.Forms;

// namespace CRUD
// {

//     public class CRUD_Vendas
//     {       
//        public void Inserir_Venda( string cliente_nome , int medicamento_id, int quantidade, DateTime data_venda, double valor_total, int atendente_id)
//        {
//             using(var con = new Conexao())
//             {
//                 con.Vendas.Add(new CRUD_Vendas {cliente_nome = cliente_nome, medicamento_id = medicamento_id, quantidade = quantidade, data_venda = data_venda, valor_total = valor_total, atendente_id = id_atendente});

//                 con.SaveChanges();
//             }
//        }

//        public void Listar_Vendas(DataGridView dgv)
//        {
//             using(var con = new Conexao())
//             {
//                 Listar = dgv.DataSource = con.Vendas.ToList();
//                 dgv.DataSource = Listar;
//             }
//        }

//         public void Atualizar_Vendas(string cliente_nome , int medicamento_id, int quantidade, DateTime data_venda, double valor_total, int atendente_id)
//         {
//             using(var con = new Conexao())
//             {
//                 var Vendas = con.Vendas.Find(id);
//                 if (Vendas != null)
//                 {
//                     Vendas.cliente_nome = cliente_nome;
//                     Vendas.medicamento_id = medicamento_id;
//                     Vendas.quantidade = quantidade; 
//                     Vendas.data_venda = data_venda;
//                     Vendas.valor_total = valor_total;
//                     Vendas.atendente_id = atendente_id;
//                     con.SaveChanges();
//                 }
//             }
//         }

//         public void Excluir_Vendas(int id) 
//         {
//             using(var con = new Conexao())
//             {
//                 var Vendas = con.Vendas.Find(id);
//                 if (Vendas != null)
//                 {
//                     con.Vendas.Remove(Vendas);
//                     con.SaveChanges();
//                 }
//             }
//         }

//     }
// }