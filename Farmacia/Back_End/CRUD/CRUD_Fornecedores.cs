using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.CRUD
{
    public class CRUD_Fornecedores
    {        
        public void Inserir_Fornecedor(string nome, string cnpj, string telefone, string endereco)
        {
            using (var con = new Conexao())
            {
                con.Fornecedores.Add(new Fornecedores
                {
                    nome = nome,
                    cnpj = cnpj,
                    telefone = telefone,
                    endereco = endereco
                });

                con.SaveChanges();
                Console.WriteLine("Fornecedor inserido com sucesso!");
            }
        }

        
        public List<Fornecedores> Listar_Fornecedores()
        {
            using (var con = new Conexao())
            {
                return con.Fornecedores.ToList();
            }
        }

       
        public void Atualizar_Fornecedor(int id, string nome, string cnpj, string telefone, string endereco)
        {
            using (var con = new Conexao())
            {
                var fornecedor = con.Fornecedores.Find(id);
                if (fornecedor != null)
                {
                    fornecedor.nome = nome;
                    fornecedor.cnpj = cnpj;
                    fornecedor.telefone = telefone;
                    fornecedor.endereco = endereco;

                    con.SaveChanges();
                    Console.WriteLine("Fornecedor atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado!");
                }
            }
        }

        public void Excluir_Fornecedor(int id)
        {
            using (var con = new Conexao())
            {
                var fornecedor = con.Fornecedores.Find(id);
                if (fornecedor != null)
                {
                    con.Fornecedores.Remove(fornecedor);
                    con.SaveChanges();
                    Console.WriteLine("Fornecedor excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado!");
                }
            }
        }

        
        public void Mostrar_Fornecedores()
        {
            var fornecedores = Listar_Fornecedores();
            foreach (var fornecedor in fornecedores)
            {
                Console.WriteLine($"ID: {fornecedor.id}, Nome: {fornecedor.nome}, CNPJ: {fornecedor.cnpj}, Telefone: {fornecedor.telefone}");
            }
        }
    }
}
