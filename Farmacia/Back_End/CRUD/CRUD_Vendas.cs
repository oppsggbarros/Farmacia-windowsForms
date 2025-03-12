using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace CRUD
{
    public class CRUD_Vendas
    {       
       public void Inserir_Venda( id_cliente, id_medicamento, quatidade, preco, data_venda, valor_total, id_atendente)
       {
            using(var con = new Conexao()
            {
                con.Vendas.Add(new CRUD_Vendas {id_cliente = id_cliente, id_medicamento = id_medicamento, quatidade = quatidade, preco = preco, data_venda = data_venda, valor_total = valor_total, id_atendente = id_atendente});

                con.SaveChanges();
            })
       }

       public void Listar_Vendas(DataGridView dgv)
       {
            using(var con = new Conexao())
            {
                Listar = dgv.DataSource = con.Vendas.ToList();
                dgv.DataSource = Listar;
            }
       }

        public void Atualizar_Vendas()

    }
}