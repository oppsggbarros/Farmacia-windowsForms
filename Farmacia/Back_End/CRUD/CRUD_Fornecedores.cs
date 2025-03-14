// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Farmacia.Back_End.CRUD
// {
//     public class CRUD_Fornecedores
//     {
//         public void Inserir_Fornecedores(string  nome , string cnpj , string telefone , string endereco)
//        {
//             using(var con = new Conexao()
//             {
//                 con.Fornecedores.Add(new CRUD_Fornecedores {nome = nome,cnpj =cnpj, telefone = telefone, endereco = endereco});

//                 con.SaveChanges();
//             })
//        }
//        public void Listar_Fornecedores(DataGridView dgv)
//        {
//             using(var con = new Conexao())
//             {
//                 Listar = dgv.DataSource = con.Fornecedores.ToList();
//                 dgv.DataSource = Listar;
//             }
//        }

//         public void Atualizar_Fornecedores(string  nome , string cnpj , string telefone , string endereco)
//         {
//             using(var con = new Conexao())
//             {
//                 var Fornecedores = con.Fornecedores.Find(id);
//                 if (Fornecedores != null)
//                 {
//                     Fornecedores.nome = nome;
//                     Fornecedores.cnpj = cnpj;
//                     Fornecedores.telefone = telefone;
//                     Fornecedores.endereco = endereco;
//                     con.SaveChanges();
//                 }
//             }
//         }

//         public void Excluir_Fornecedores(int id) 
//         {
//             using(var con = new Conexao())
//             {
//                 var Fornecedores = con.Fornecedores.Find(id);
//                 if (Fornecedores != null)
//                 {
//                     con.Fornecedores.Remove(Fornecedores);
//                     con.SaveChanges();
//                 }
//             }
//         }
//     }
// }