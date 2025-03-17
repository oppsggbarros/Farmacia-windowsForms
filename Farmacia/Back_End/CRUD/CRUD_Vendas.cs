using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.CRUD
{
    public class CRUD_Vendas
    {

        public void Inserir_Venda(string cliente_nome, int medicamento_id, int quantidade, DateTime data_venda, decimal valor_total, int atendente_id)
        {
            data_venda = data_venda.ToUniversalTime();
            try
            {
                using (var con = new Conexao())
                {
                    con.Vendas.Add(new Vendas
                    {
                        cliente_nome = cliente_nome,
                        medicamento_id = medicamento_id,
                        quantidade = quantidade,
                        data_venda = data_venda,
                        valor_total = valor_total,
                        atendente_id = atendente_id
                    });

                    con.SaveChanges();
                    Console.WriteLine("Venda registrada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar venda: " + ex.Message);
            }
        }

       
        public List<Vendas> Listar_Vendas()
        {
            try
            {
                
                using (var con = new Conexao())
                {
                    return con.Vendas.ToList();
                }
            }
            catch (System.Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return new List<Vendas>();
            }
        }

        
        public void Atualizar_Venda(int id, string cliente_nome, int medicamento_id, int quantidade, DateTime data_venda, decimal valor_total, int atendente_id)
        {
            try 
            {
                
                using (var con = new Conexao())
                {
                    data_venda = data_venda.ToUniversalTime();
                    var venda = con.Vendas.Find(id);
                    if (venda != null)
                    {
                        venda.cliente_nome = cliente_nome;
                        venda.medicamento_id = medicamento_id;
                        venda.quantidade = quantidade;
                        venda.data_venda = data_venda;
                        venda.valor_total = valor_total;
                        venda.atendente_id = atendente_id;

                        con.SaveChanges();
                        Console.WriteLine("Venda atualizada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Venda não encontrada!");
                    }
                }
            
            }

            catch (System.Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }   
        }

        
        public void Excluir_Venda(int id)
        {
            try
            {
                using (var con = new Conexao())
            {
                var venda = con.Vendas.Find(id);
                if (venda != null)
                {
                    con.Vendas.Remove(venda);
                    con.SaveChanges();
                    Console.WriteLine("Venda excluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("Venda não encontrada!");
                }
            }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        public void Mostrar_Vendas()
        {
            var vendas = Listar_Vendas();
            foreach (var venda in vendas)
            {
                Console.WriteLine($"ID: {venda.id}, Cliente: {venda.cliente_nome}, Medicamento: {venda.medicamento_id}, Quantidade: {venda.quantidade}, Valor Total: {venda.valor_total}");
            }
        }
    }
}
