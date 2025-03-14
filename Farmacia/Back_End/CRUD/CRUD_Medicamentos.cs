using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.CRUD
{
    public class CRUD_Medicamentos
    {
        private readonly DbContextOptions<Conexao> _options;

        public CRUD_Medicamentos()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Conexao>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=DesafioFarmacia;Username=postgres;Password=#Vasco2024");
            _options = optionsBuilder.Options;
        }

        public void Inserir_Medicamento(string nome, string descricao, string tipo, double preco, int estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao(_options))
            {
                con.Medicamentos.Add(new Medicamentos
                {
                    nome = nome,
                    descricao = descricao,
                    tipo = tipo,
                    preco = preco,
                    estoque_atual = estoque_atual,
                    data_validade = data_validade
                });
                con.SaveChanges();
                Console.WriteLine("Medicamento inserido com sucesso!");
            }
        }

        public void Listar_Medicamentos()
        {
            using (var con = new Conexao(_options))
            {
                var medicamentos = con.Medicamentos.ToList();
                foreach (var medicamento in medicamentos)
                {
                    Console.WriteLine($"ID: {medicamento.id}, Nome: {medicamento.nome}, Preço: {medicamento.preco}");
                }
            }
        }

        public void Deletar_Medicamento(int id)
        {
            using (var con = new Conexao(_options))
            {
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    con.Medicamentos.Remove(medicamento);
                    con.SaveChanges();
                    Console.WriteLine("Medicamento deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }

        public void Atualizar_Medicamento(int id, string nome, string descricao, string tipo, double preco, int estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao(_options))
            {
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    medicamento.nome = nome;
                    medicamento.descricao = descricao;
                    medicamento.tipo = tipo;
                    medicamento.preco = preco;
                    medicamento.estoque_atual = estoque_atual;
                    medicamento.data_validade = data_validade;
                    con.SaveChanges();
                    Console.WriteLine("Medicamento atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }
    }
}
